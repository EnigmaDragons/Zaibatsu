using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class CurrentGameCalendar : ScriptableObject
{
    [SerializeField] private StaticCalendar staticCalendar;
    [SerializeField] private List<CalendarEvent> transientLocalEvents;

    private HashSet<string> _completedEvents = new HashSet<string>();

    public void Init()
    {
        _completedEvents = new HashSet<string>();
        transientLocalEvents = new List<CalendarEvent>();
    }

    public void Reset()
    {
        _completedEvents = new HashSet<string>();
        transientLocalEvents = new List<CalendarEvent>();
    }

    public void Schedule(CalendarEvent e) => transientLocalEvents.Add(e);
    
    public void StartEventIfApplicable(CurrentSequence seq, Location currentLocation, GameTime currentTime)
    {
        var globalEvent = GlobalEventFor(currentTime);
        if (globalEvent.IsPresent)
        {
            MarkEventTriggered(globalEvent.Value.Id);
            seq.StartSequence(globalEvent.Value.SequenceName);
            return;
        }

        var localEvent = LocalEventFor(currentLocation, currentTime);
        if (localEvent.IsPresent)
        {
            MarkEventTriggered(localEvent.Value.Id);
            seq.StartSequence(localEvent.Value.SequenceName);
        }
    }

    private void MarkEventTriggered(string id)
    {
        _completedEvents.Add(id);
    }
    
    private Maybe<CalendarEvent> LocalEventFor(Location location, GameTime time)
    {
        // TODO: Data partitioning later for performance
        foreach(var e in staticCalendar.AllLocalEvents.Concat(transientLocalEvents))
            if (e.Location == location && e.IsActiveAt(time))
                if (e.IsRecurring || !_completedEvents.Contains(e.Id))
                    return e;
        return Maybe<CalendarEvent>.Missing();
    }

    private Maybe<CalendarGlobalEvent> GlobalEventFor(GameTime time)
    {
        // TODO: Data partitioning later for performance
        foreach(var e in staticCalendar.AllGlobalEvents)
            if (e.IsActiveAt(time))
                return e;
        return Maybe<CalendarGlobalEvent>.Missing();
    }
}
