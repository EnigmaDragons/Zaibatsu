using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class StaticCalendar : ScriptableObject
{
    [SerializeField] private CalendarEventAsset[] eventAssets;
    [SerializeField] private CalendarEvent[] events;
    [SerializeField] private CalendarGlobalEventAsset[] globalEventAssets;

    public CalendarEvent[] AllLocalEvents 
        => eventAssets.Select(e => e.AsEvent())
            .Concat(events ?? Enumerable.Empty<CalendarEvent>())
            .ToArray();

    public CalendarGlobalEvent[] AllGlobalEvents
        => globalEventAssets.Select(g => g.AsEvent())
            .ToArray();
}