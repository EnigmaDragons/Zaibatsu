using UnityEngine;

public sealed class OnArrivedStartRelevantCalendarEvent : OnMessage<ArrivedAtLocation>
{
    [SerializeField] private CurrentGameCalendar calendar;
    [SerializeField] private CurrentGameState game;
    [SerializeField] private CurrentSequence sequence;
    
    protected override void Execute(ArrivedAtLocation msg) 
        => calendar
            .LocalEventFor(msg.Location, game.State.Time)
            .IfPresent(e =>
            {
                if (e.IsRecurring)
                    calendar.MarkEventTriggered(e.Id);
                sequence.StartSequence(e.SequenceName);
            });
}