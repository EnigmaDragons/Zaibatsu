using System;

[Serializable]
public sealed class CalendarGlobalEvent
{
    public string Description { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string SequenceName { get; set; }

    public override string ToString() => $"Global: {StartTime}-{EndTime} - {Description}";

    public bool IsActiveAt(GameTime time)
        => time.TotalMinutes >= GameTime.Parse(StartTime).TotalMinutes
           && time.TotalMinutes < GameTime.Parse(EndTime).TotalMinutes;
}
