using System.Linq;
using UnityEngine;

public class GameSequenceOrchestrator : SequenceOrchestrator
{
    [SerializeField] private SpriteResource[] sprites;
    [SerializeField] private Character[] characters;
    [SerializeField] private Location[] locations;

    protected override void PopulateScriptableOnEvent(object e, ScriptableData data)
    {
        var property = e.GetType().GetProperty(data.PropertyName);
        if (data.Type == typeof(SpriteResource).Name)
            property.SetValue(e, sprites.First(x => x.name == data.Name));
        else if (data.Type == typeof(Character).Name)
            property.SetValue(e, characters.First(x => x.name == data.Name));
        else if (data.Type == typeof(Location).Name)
            property.SetValue(e, locations.First(x => x.name == data.Name));
    }
}