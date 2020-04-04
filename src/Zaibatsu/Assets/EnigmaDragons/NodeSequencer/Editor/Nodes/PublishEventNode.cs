using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PublishEventNode : INodeContent
{
    private readonly IElement _eventElement;
    private readonly List<IElement> _propertyElements = new List<IElement>();

    private string _eventType;
    private Dictionary<string, object> _properties = new Dictionary<string, object>();

    public string Name => NodeTypes.PublishEvent;
    public float Width => _eventElement.Width;
    public float Height => _eventElement.Height + _propertyElements.Sum(x => x.Height) + _propertyElements.Count * EditorConstants.NodePadding;

    public PublishEventNode(IMediaType mediaType, string media) : this(mediaType, mediaType.ConvertFrom<PublishEventNodeData>(media)) { }
    public PublishEventNode() : this(GameEventList.Types.First().AssemblyQualifiedName, new Dictionary<string, object>()) { }
    private PublishEventNode(IMediaType mediaType, PublishEventNodeData data) : this(data.EventType, mediaType.ConvertFrom<Dictionary<string, object>>(data.Properties)) { }
    private PublishEventNode(string eventType, Dictionary<string, object> properties)
    {
        _eventType = eventType;
        _properties = properties;
        Type.GetType(_eventType).GetProperties().ForEach(prop =>
        {
            if (prop.PropertyType == typeof(string))
            {
                var startValue = _properties.ContainsKey(prop.Name) ? _properties[prop.Name].ToString() : "";
                _propertyElements.Add(new ElementLabel(new ExpandingTextField(startValue, str => _properties[prop.Name] = str), prop.Name));
                _properties[prop.Name] = startValue;
            }
        });

        var eventDictionary = new Dictionary<string, Action>();
        GameEventList.Types.ForEach(x =>
        {
            eventDictionary[x.AssemblyQualifiedName] = () =>
            {
                if (_eventType == x.AssemblyQualifiedName)
                    return;
                _propertyElements.Clear();
                _properties.Clear();
                _eventType = x.AssemblyQualifiedName;
                x.GetProperties().ForEach(prop =>
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        _propertyElements.Add(new ElementLabel(new ExpandingTextField("", str => _properties[prop.Name] = str), prop.Name));
                        _properties[prop.Name] = "";
                    }
                });
            };
        });
        _eventElement = new ElementLabel(new OptionsElement(eventDictionary, _eventType, 200), "Event");
    }

    public void Draw(Vector2 position)
    {
        _eventElement.Draw(position);
        for (var i = _propertyElements.Count; i > 0; i--)
        {
            var heightAdded = _propertyElements.Take(i - 1).Any() ? _propertyElements.Take(i - 1).Sum(x => x.Height) : 0;
            _propertyElements[i - 1].Draw(position + new Vector2(0, _eventElement.Height + (EditorConstants.NodePadding * i) + heightAdded));
        }
    }

    public INodeContent Duplicate() => new PublishEventNode(_eventType, _properties);
    public string Save(IMediaType mediaType)
    {
        var props = mediaType.ConvertTo(_properties);
        Debug.Log(props);
        return mediaType.ConvertTo(new PublishEventNodeData
        { EventType = _eventType, Properties = props });
    }
}

[Serializable]
public class PublishEventNodeData
{
    public string EventType;
    public string Properties;
}