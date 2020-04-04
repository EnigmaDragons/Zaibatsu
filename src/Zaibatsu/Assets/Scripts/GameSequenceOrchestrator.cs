using System.Linq;
using UnityEngine;

public class GameSequenceOrchestrator : SequenceOrchestrator
{
    [SerializeField] private SpriteResource[] sprites;

    protected override void PopulateScriptableOnEvent(object e, ScriptableData data)
    {
        if (data.Type == typeof(SpriteResource).Name)
            e.GetType().GetProperty(data.PropertyName).SetValue(e, sprites.First(x => x.name == data.Name));
    }
}