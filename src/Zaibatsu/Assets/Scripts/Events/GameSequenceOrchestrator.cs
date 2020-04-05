using System.Linq;
using UnityEngine;

public class GameSequenceOrchestrator : SequenceOrchestrator
{
    [SerializeField] private StringVariable[] strings;
    [SerializeField] private IntVariable[] ints;
    [SerializeField] private BoolVariable[] bools;

    [SerializeField] private SpriteResource[] sprites;
    [SerializeField] private Character[] characters;
    [SerializeField] private Location[] locations;
    [SerializeField] private CurrentGameState gameState;

    protected override void SetScriptableVariable(SetVariableData data)
    {
        if (data.Type == ConditionType.String)
            strings.First(x => x.name == data.VariableName).Value = data.StringValue;
        else if (data.Type == ConditionType.Int && data.IntOperation == IntOperation.Set)
            ints.First(x => x.name == data.VariableName).Value = data.IntValue;
        else if (data.Type == ConditionType.Int && data.IntOperation == IntOperation.Add)
            ints.First(x => x.name == data.VariableName).Value += data.IntValue;
        else if (data.Type == ConditionType.Bool)
            bools.First(x => x.name == data.VariableName).Value = data.BoolValue;
    }

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

    protected override bool IsCustomConditionMet(ConditionData data)
    {
        if (data.CustomType == NodeTypes.ItemPresentCondition)
            return gameState.IsItemPresent(_mediaType.ConvertFrom<ItemPresentConditionData>(data.ConditionContent).Item);
        return false;
    }
}