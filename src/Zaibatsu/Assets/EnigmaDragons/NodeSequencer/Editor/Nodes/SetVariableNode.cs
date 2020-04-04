using System;
using System.Collections.Generic;
using UnityEngine;

public class SetVariableNode : INodeContent
{
    private readonly IElement _variableNameElement;
    private readonly IElement _variableTypeElement;
    private readonly IElement _stringValueElement;
    private readonly IElement _intOperationElement;
    private readonly IElement _intValueElement;
    private readonly BoolElement _boolValueElement;

    private string _name;
    private ConditionType _type;
    private string _stringValue;
    private IntOperation _intOperation;
    private int _intValue;

    public string Name => NodeTypes.SetVariable;
    public float Width => _variableNameElement.Width;
    public float Height => _variableNameElement.Height + _variableTypeElement.Height + EditorConstants.NodePadding * 2 +
        (_type == ConditionType.Int ? _intOperationElement.Height + _intValueElement.Height + EditorConstants.NodePadding : _stringValueElement.Height);

    public SetVariableNode(IMediaType mediaType, string media) 
        : this(mediaType.ConvertFrom<SetVariableNodeData>(media)) {}

    public SetVariableNode() : this("", ConditionType.String, "", IntOperation.Set, 0, true) {}

    private SetVariableNode(SetVariableNodeData data) 
        : this(data.Name, data.Type, data.StringValue, data.IntOperation, data.IntValue, data.BoolValue) {}

    private SetVariableNode(string name, ConditionType type, string stringValue, IntOperation intOperation, int intValue, bool boolValue)
    {
        _name = name;
        _type = type;
        _stringValue = stringValue;
        _intOperation = intOperation;
        _intValue = intValue;
        _variableNameElement = new ElementLabel(new ExpandingTextField(_name, x => _name = x), "Name");
        _variableTypeElement = new ElementLabel(new OptionsElement(new Dictionary<string, Action>
        {
            { nameof(ConditionType.String), () => _type = ConditionType.String },
            { nameof(ConditionType.Int), () => _type = ConditionType.Int },
            { nameof(ConditionType.Bool), () => _type = ConditionType.Bool }
        }, Enum.GetName(typeof(ConditionType), _type), 200), "Type");
        _stringValueElement = new ElementLabel(new ExpandingTextField(_stringValue, x => _stringValue = x), "Value");
        _intOperationElement = new ElementLabel(new OptionsElement(new Dictionary<string, Action>
        {
            { nameof(IntOperation.Set), () => _intOperation = IntOperation.Set },
            { nameof(IntOperation.Add), () => _intOperation = IntOperation.Add }
        }, Enum.GetName(typeof(IntOperation), _intOperation), 200), "Operation");
        _intValueElement = new ElementLabel(new ExpandingTextField(_intValue.ToString(), x => int.TryParse(x, out _intValue)), "Value");
        _boolValueElement = new BoolElement("Value", boolValue, 200);
    }

    public void Draw(Vector2 position)
    {
        if (_type == ConditionType.Bool)
            _boolValueElement.Draw(new Vector2(position.x, position.y + _variableNameElement.Height + _variableTypeElement.Height + EditorConstants.NodePadding * 2));
        if (_type == ConditionType.Int)
        {
            _intOperationElement.Draw(new Vector2(position.x, position.y + _variableNameElement.Height + _variableTypeElement.Height + EditorConstants.NodePadding * 2));
            _intValueElement.Draw(new Vector2(position.x, position.y + _variableNameElement.Height + _variableTypeElement.Height + _intOperationElement.Height + EditorConstants.NodePadding * 3));
        }
        if (_type == ConditionType.String)
            _stringValueElement.Draw(new Vector2(position.x, position.y + _variableNameElement.Height + _variableTypeElement.Height + EditorConstants.NodePadding * 2));
        _variableTypeElement.Draw(new Vector2(position.x, position.y + _variableNameElement.Height + EditorConstants.NodePadding));
        _variableNameElement.Draw(position);
    }

    public INodeContent Duplicate() => new SetVariableNode(_name, _type, _stringValue, _intOperation, _intValue, _boolValueElement.Value);

    public string Save(IMediaType mediaType) => mediaType.ConvertTo(new SetVariableNodeData
    {
        Name = _name,
        Type = _type,
        StringValue = _stringValue,
        IntOperation = _intOperation,
        IntValue = _intValue,
        BoolValue = _boolValueElement.Value
    });
}

[Serializable]
public class SetVariableNodeData
{
    public string Name;
    public ConditionType Type;
    public string StringValue;
    public IntOperation IntOperation;
    public int IntValue;
    public bool BoolValue;
}
