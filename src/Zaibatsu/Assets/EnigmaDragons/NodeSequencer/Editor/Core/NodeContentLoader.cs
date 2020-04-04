using System;
using System.Collections.Generic;
using Assets.Scripts.Editor.Dialogue;

public class NodeContentLoader
{
    private readonly Dictionary<string, Func<IMediaType, string, Node, INodeContent>> _loadContent;

    public NodeContentLoader(Action<Node> addChoiceNode, Action<Node> addConditionNode, Action<Node> addConditionalChoice, Func<List<string>> getDialogues)
    {
        _loadContent = new Dictionary<string, Func<IMediaType, string, Node, INodeContent>>
        {
            { NodeTypes.Choices, (mediaType, media, node) => new ChoicesNode(() => addChoiceNode(node), () => addConditionalChoice(node)) },
            { NodeTypes.Choice, (mediaType, media, node) => new ChoiceNode(mediaType, media) },
            { NodeTypes.GoToSequence, (mediaType, media, node) => new GoToDialogueNode(getDialogues(), mediaType, media) },
            { NodeTypes.SetVariable, (mediaType, media, node) => new SetVariableNode(mediaType, media) },
            { NodeTypes.Switch, (mediaType, media, node) => new ConditionalNode(() => addConditionNode(node)) },
            { NodeTypes.Condition, (mediaType, media, node) => new ConditionNode(() => addChoiceNode(node), mediaType, media) },
            { NodeTypes.PublishEvent, (mediaType, media, node) => new PublishEventNode(mediaType, media) },
        };
    }

    public INodeContent Load(IMediaType mediaType, Node parentNode, string type, string media)
    {
        if (_loadContent.ContainsKey(type))
            return _loadContent[type](mediaType, media, parentNode);
        return new ErrorNode(type + " Error");
    }
}
