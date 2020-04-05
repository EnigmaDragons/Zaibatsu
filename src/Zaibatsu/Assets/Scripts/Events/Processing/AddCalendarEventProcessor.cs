using UnityEngine;

public class AddCalendarEventProcessor : OnMessage<AddCalendarEvent>
{
    [SerializeField] private CurrentGameCalendar calendar;
    [SerializeField] private CurrentGameState game;
    
    protected override void Execute(AddCalendarEvent msg) 
        => calendar.Schedule(msg.AsCalendarEvent(game.Time));
}
