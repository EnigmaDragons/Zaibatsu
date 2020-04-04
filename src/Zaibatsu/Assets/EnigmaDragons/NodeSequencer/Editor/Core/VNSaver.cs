﻿using System.Collections.Generic;
using System.Linq;

public class VNSaver
{
    private readonly IStorage _storage;
    private readonly IMediaType _mediaType;

    public VNSaver(IStorage storage, IMediaType mediaType)
    {
        _storage = storage;
        _mediaType = mediaType;
    }

    public void Save(NodeEditorData data, string saveName)
    {
        var connections = data.Connections.Select(x => _mediaType.ConvertFrom<ConnectionData>(x)).ToList();
        var nodes = data.Nodes.Select(x => _mediaType.ConvertFrom<NodeData>(x)).ToList();
        if (connections.None(x => x.OutNodeID == _mediaType.ConvertFrom<StartNodeData>(data.StartNode).ID))
            return;
        var startConnection = connections.First(x => x.OutNodeID == _mediaType.ConvertFrom<StartNodeData>(data.StartNode).ID);
        var steps = nodes
            .Where(node => node.Type != NodeTypes.Choice)
            .Select(node => GetSequenceStepData(node, connections, nodes)).ToList();
        _storage.Put(saveName, new SequenceData { StartID = startConnection.InNodeID, Steps = steps });
    }

    private SequenceStepData GetSequenceStepData(NodeData node, List<ConnectionData> connections, List<NodeData> nodes)
    {
        var stepData = new SequenceStepData { ID = node.ID, Type = node.Type };
        if (stepData.Type == NodeTypes.Condition)
            SetConditionData(stepData, node, connections, nodes);
        else if (stepData.Type == NodeTypes.Choices)
            SetChoiceData(stepData, node, connections, nodes);
        else if (stepData.Type == NodeTypes.GoToSequence)
            SetGoToDialogueData(stepData, node);
        else if (stepData.Type == NodeTypes.SetVariable)
            SetSetVariableData(stepData, node, connections);
        else if (stepData.Type == NodeTypes.Switch)
            SetConditionalData(stepData, node, connections, nodes);
        return stepData;
    }

    private void SetConditionData(SequenceStepData stepData, NodeData node, List<ConnectionData> connections, List<NodeData> nodes)
    {
        var content = _mediaType.ConvertFrom<ConditionNodeData>(node.Content);
        var conditionContent = "";
        if (content.Type == ConditionType.String)
            conditionContent = _mediaType.ConvertTo(new StringConditionData
            {
                VariableName = content.Name,
                StringValue = content.StringValue
            });
        else if (content.Type == ConditionType.Int)
            conditionContent = _mediaType.ConvertTo(new IntConditionData
            {
                VariableName = content.Name,
                IntComparison = content.IntComparison,
                IntValue = content.IntValue,
                IntValue2 = content.IntValue2
            });
        else if (content.Type == ConditionType.Bool)
            conditionContent = _mediaType.ConvertTo(new BoolConditionData
            {
                VariableName = content.Name,
                BoolValue = content.BoolValue
            });
        else if (content.Type == ConditionType.And || content.Type == ConditionType.Or)
            conditionContent = _mediaType.ConvertTo(new MultiConditionData
            {
                ConditionIDs = connections
                    .Where(connection => connection.OutNodeID == node.ID && nodes.Any(x => x.ID == connection.InNodeID && x.Type == NodeTypes.Condition))
                    .Select(x => x.InNodeID)
                    .ToList()
            });
        stepData.Content = _mediaType.ConvertTo(new ConditionData
        {
            NextID = connections.FirstOrDefault(connection => connection.OutNodeID == node.ID && nodes.First(x => x.ID == connection.InNodeID).Type != NodeTypes.Condition)?.InNodeID,
            Type = content.Type,
            ConditionContent = conditionContent
        });
    }

    private void SetChoiceData(SequenceStepData stepData, NodeData node, List<ConnectionData> connections, List<NodeData> nodes)
    {
        stepData.Content = _mediaType.ConvertTo(new GiveChoicesData
        {
            Choices = nodes
                .Where(choiceNode => choiceNode.Type == NodeTypes.Choice 
                    && connections.Any(connection => connection.OutNodeID == node.ID && connection.InNodeID == choiceNode.ID))
                .Select(choiceNode => new ChoiceData
                {
                    NextID = GetNextID(choiceNode, connections),
                    Choice = _mediaType.ConvertFrom<ChoiceNodeData>(choiceNode.Content).Choice,
                    HasCondition = false
                })
                .Concat(nodes
                    .Where(conditionNode => conditionNode.Type == NodeTypes.Condition 
                        && connections.Any(connection => connection.OutNodeID == node.ID && connection.InNodeID == conditionNode.ID)
                        && connections.Any(connection => connection.OutNodeID == conditionNode.ID 
                            && nodes.Any(choiceNode => connection.InNodeID == choiceNode.ID && choiceNode.Type == NodeTypes.Choice)))
                    .Select(conditionNode =>
                    {
                        var choiceNode = nodes.First(possibleNode => possibleNode.Type == NodeTypes.Choice 
                            && connections.Any(x => x.OutNodeID == conditionNode.ID && x.InNodeID == possibleNode.ID));
                        return new ChoiceData
                        {
                            NextID = GetNextID(choiceNode, connections),
                            Choice = _mediaType.ConvertFrom<ChoiceNodeData>(choiceNode.Content).Choice,
                            HasCondition = true,
                            ConditionID = conditionNode.ID
                        };
                    }))
                .ToList()
        });
    }

    private void SetGoToDialogueData(SequenceStepData stepData, NodeData node)
    {
        var content = _mediaType.ConvertFrom<GoToDialogueNodeData>(node.Content);
        stepData.Content = _mediaType.ConvertTo(new GoToSequenceData { Sequence = content.Dialogue });
    }

    private void SetSetVariableData(SequenceStepData stepData, NodeData node, List<ConnectionData> connections)
    {
        var content = _mediaType.ConvertFrom<SetVariableNodeData>(node.Content);
        stepData.Content = _mediaType.ConvertTo(new SetVariableData
        {
            NextID = GetNextID(node, connections),
            VariableName = content.Name,
            Type = content.Type,
            StringValue = content.StringValue,
            IntOperation = content.IntOperation,
            IntValue = content.IntValue,
            BoolValue = content.BoolValue
        });
    }

    private void SetConditionalData(SequenceStepData stepData, NodeData node, List<ConnectionData> connections, List<NodeData> nodes)
    {
        stepData.Content = _mediaType.ConvertTo(new ConditionalData
        {
            ElseNextID = connections.Where(connection => connection.OutNodeID == node.ID)
                .FirstOrDefault(connection => nodes.First(x => x.ID == connection.InNodeID).Type != NodeTypes.Condition)?.InNodeID,
            ConditionIDs = connections
                .Where(connection => connection.OutNodeID == node.ID && nodes.First(x => x.ID == connection.InNodeID).Type == NodeTypes.Condition)
                .Select(connection => connection.InNodeID)
                .ToList()
        });
    }

    private string GetNextID(NodeData node, List<ConnectionData> connections)
    {
        return connections.FirstOrDefault(x => x.OutNodeID == node.ID)?.InNodeID;
    } 
}
