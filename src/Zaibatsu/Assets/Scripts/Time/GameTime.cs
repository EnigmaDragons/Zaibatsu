using System;

[Serializable]
public struct GameTime
{
    public int TotalMinutes { get; }
    public int CurrentHour => TotalMinutes / 60;
    public int CurrentMinute => TotalMinutes % 60;
    public string Time => $"{CurrentHour.ToString().PadLeft(2, '0')}:{CurrentMinute.ToString().PadLeft(2, '0')}";

    public GameTime(int totalMinutes) => TotalMinutes = totalMinutes;
}
