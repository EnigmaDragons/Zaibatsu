using System.Linq;
using UnityEngine;

public class GameSequenceOrchestrator : SequenceOrchestrator
{
    [SerializeField] private SpriteResource[] sprites;
    [SerializeField] private Character[] characters;

    protected override void PopulateScriptableOnEvent(object e, ScriptableData data)
    {
        if (data.Type == typeof(SpriteResource).Name)
            e.GetType().GetProperty(data.PropertyName).SetValue(e, sprites.First(x => x.name == data.Name));
        if (data.Type == typeof(Character).Name)
            e.GetType().GetProperty(data.PropertyName).SetValue(e, characters.First(x => x.name == data.Name));
    }
}