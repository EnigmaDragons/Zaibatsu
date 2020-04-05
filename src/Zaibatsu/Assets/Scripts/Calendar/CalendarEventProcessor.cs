
using UnityEngine;

public class CalendarEventProcessor : OnMessage<GameStateChanged, CurrentLocationChanged, SequenceStateChanged>
{
    [SerializeField] private CurrentGameCalendar calendar;
    [SerializeField] private CurrentGameState game;
    [SerializeField] private CurrentSequence sequence;

    protected override void Execute(GameStateChanged msg) => StartEventIfApplicable(game.CurrentLocation, msg.State.Time);
    protected override void Execute(CurrentLocationChanged msg) => StartEventIfApplicable(msg.Location, game.Time);
    protected override void Execute(SequenceStateChanged msg) => StartEventIfApplicable(game.CurrentLocation, game.Time);

    private void StartEventIfApplicable(Location location, GameTime time)
    {
        if (!sequence.IsActive)
            calendar.StartEventIfApplicable(sequence, location, time);
    }
}
