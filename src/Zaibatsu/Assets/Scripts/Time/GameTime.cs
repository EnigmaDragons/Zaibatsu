
using System;

public struct GameTime
{
    public int TotalMinutes { get; }
    public int CurrentHour => TotalMinutes / 60;
    public int CurrentMinute => TotalMinutes % 60;
    public string Time => $"{CurrentHour.ToString().PadLeft(2, '0')}:{CurrentMinute.ToString().PadLeft(2, '0')}";

    public GameTime(int totalMinutes) => TotalMinutes = totalMinutes;

    public override string ToString() => Time;

    public static GameTime Parse(string hhmm)
    {
        if (TryParse(hhmm, out var time))
            return time;
        throw new ArgumentException($"{hhmm}");
    }
    
    public static bool TryParse(string hhmm, out GameTime gameTime)
    {
        var parts = hhmm.Split(':');
        if (parts.Length < 2)
        {
            gameTime = new GameTime();
            return false;
        }

        gameTime = new GameTime(int.Parse(parts[0]) * 60 + int.Parse(parts[1]));
        return true;
    }
}
