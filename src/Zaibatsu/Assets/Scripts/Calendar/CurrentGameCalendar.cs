using UnityEngine;

[CreateAssetMenu]
public class CurrentGameCalendar : ScriptableObject
{
    [SerializeField] private StaticCalendar staticCalendar;
    
    public Maybe<CalendarEvent> EventFor(Location location, GameTime time)
    {
        // TODO: Data partitioning later for performance
        foreach(var e in staticCalendar.AllEvents)
            if (e.Location == location && e.IsActiveAt(time))
                return e;
        return Maybe<CalendarEvent>.Missing();
    }
}
