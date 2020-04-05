
// TODO: This design is the absolute worst! We need to redo this completely.
public class AddCalendarEvent
{
    public CalendarEventAsset CalendarEvent { get; set; }
    public bool RelativeTime { get; set; }
    public string StartTime { get; set; }
    public bool TilEnd { get; set; }
    public string EndTime { get; set; }

    public CalendarEvent AsCalendarEvent(GameTime current)
    {
        var e = CalendarEvent.AsEvent();
        e.StartTime = GetEventStartTime(current).Time;
        e.EndTime = GetEventEndTime(current).Time;
        return e;
    }

    public GameTime GetEventStartTime(GameTime current)
        => RelativeTime
            ? current + GameTime.Parse(StartTime)
            : GameTime.Parse(StartTime);

    public GameTime GetEventEndTime(GameTime current)
        => TilEnd
            ? HardcodedDayBoundaries.End
            : RelativeTime
                ? current + GameTime.Parse(EndTime)
                : GameTime.Parse(EndTime);
}