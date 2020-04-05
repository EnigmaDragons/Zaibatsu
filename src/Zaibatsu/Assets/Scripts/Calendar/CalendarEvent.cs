using System;

[Serializable]
public sealed class CalendarEvent
{
    public Location Location { get; set; }
    public string Description { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string SequenceName { get; set; }
    public bool IsRecurring { get; set; }

    public string Id => $"{Location.DisplayName} {SequenceName}";
    
    public override string ToString() 
        => $"{Location.DisplayName}: {StartTime}-{EndTime} - {(IsRecurring ? "Recurring" : "Once")} - {Description}";

    public bool IsActiveAt(GameTime time) 
        => time.TotalMinutes >= GameTime.Parse(StartTime).TotalMinutes 
        && time.TotalMinutes <= GameTime.Parse(EndTime).TotalMinutes;
}