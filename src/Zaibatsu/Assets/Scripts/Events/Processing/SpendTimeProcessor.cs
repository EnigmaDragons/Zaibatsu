using UnityEngine;

public class SpendTimeProcessor : OnMessage<SpendTime>
{
    [SerializeField] private CurrentGameState game;

    protected override void Execute(SpendTime msg)
    {
        game.UpdateState(gs => gs.CurrentRawGameTime += msg.NumMinutes);
        Message.Publish(new SequenceStepFinished());
    }
}
