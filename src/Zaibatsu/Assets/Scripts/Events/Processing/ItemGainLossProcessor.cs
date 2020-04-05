
using UnityEngine;

public class ItemGainLossProcessor : OnMessage<GainItem, LoseItem>
{
    [SerializeField] private CurrentGameState game;

    protected override void Execute(GainItem msg)
    {
        game.AddItem(msg.Item);
        Message.Publish(new SequenceStepFinished());
    }

    protected override void Execute(LoseItem msg)
    {
        game.RemoveItem(msg.Item);
        Message.Publish(new SequenceStepFinished());
    }
}
