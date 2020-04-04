using System;

[Serializable]
public class SetVariableData
{
    public string NextID;
    public string VariableName;
    public ConditionType Type;
    public string StringValue;
    public IntOperation IntOperation;
    public int IntValue;
    public bool BoolValue;
}