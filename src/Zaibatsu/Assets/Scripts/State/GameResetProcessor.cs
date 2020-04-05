using UnityEngine;

public sealed class GameResetProcessor : OnMessage<ResetDay>
{
    [SerializeField] private CurrentGameState game;

    protected override void Execute(ResetDay msg)
    {
        game.Reset();
        Message.Publish(new SequenceStateChanged());
    } 
}
