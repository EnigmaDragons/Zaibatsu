using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class StaticCalendar : ScriptableObject
{
    [SerializeField] private CalendarEventAsset[] eventAssets;
    [SerializeField] private CalendarEvent[] events;

    public CalendarEvent[] AllEvents 
        => eventAssets.Select(e => e.AsEvent())
            .Concat(events ?? Enumerable.Empty<CalendarEvent>())
            .ToArray();
}