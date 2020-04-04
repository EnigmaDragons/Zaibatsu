using System;

[Serializable]
public sealed class GameState
{
    public int NumCredits { get; set; }
    public int NumNanoconstructors { get; set; }
    public GameTime Time => new GameTime(CurrentRawGameTime);
    public int CurrentRawGameTime { get; set; }
}
