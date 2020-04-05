using UnityEngine;

public class ResetGameOnClockRunOut : OnMessage<GameStateChanged>
{
    [SerializeField] private int gameEndTimeMinutes = 1600;
    
    protected override void Execute(GameStateChanged msg)
    {
        if (msg.State.CurrentRawGameTime > gameEndTimeMinutes)
            Message.Publish(new ResetDay());
    }
}De