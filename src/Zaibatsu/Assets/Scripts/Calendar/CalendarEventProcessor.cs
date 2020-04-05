
using UnityEngine;

// TODO Implement this logic in #100
public class CalendarEventProcessor : OnMessage<GameStateChanged, ArrivedAtLocation, SequenceStateChanged>
{
    [SerializeField] private CurrentGameCalendar calendar;
    [SerializeField] private CurrentGameState game;
    [SerializeField] private CurrentSequence sequence;

    protected override void Execute(GameStateChanged msg)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(ArrivedAtLocation msg) 
        => calendar
            .LocalEventFor(msg.Location, game.State.Time)
            .IfPresent(e => sequence.StartSequence(e.SequenceName));

    protected override void Execute(SequenceStateChanged msg)
    {
        throw new System.NotImplementedException();
    }
}
