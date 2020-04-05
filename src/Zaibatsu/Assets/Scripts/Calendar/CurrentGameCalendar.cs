using UnityEngine;

[CreateAssetMenu]
public class CurrentGameCalendar : ScriptableObject
{
    [SerializeField] private StaticCalendar staticCalendar;
    
    public Maybe<CalendarEvent> LocalEventFor(Location location, GameTime time)
    {
        // TODO: Data partitioning later for performance
        foreach(var e in staticCalendar.AllLocalEvents)
            if (e.Location == location && e.IsActiveAt(time))
                return e;
        return Maybe<CalendarEvent>.Missing();
    }

    public Maybe<CalendarGlobalEvent> GlobalEventFor(GameTime time)
    {
        // TODO: Data partitioning later for performance
        foreach(var e in staticCalendar.AllGlobalEvents)
            if (e.IsActiveAt(time))
                return e;
        return Maybe<CalendarGlobalEvent>.Missing();
    }
}
