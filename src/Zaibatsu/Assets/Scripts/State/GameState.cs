using System;
using System.Collections.Generic;

[Serializable]
public sealed class GameState
{
    // Transient Inventory
    public int NumCredits { get; set; }
    public int NumNanoconstructors { get; set; }
    public GameTime Time => new GameTime(CurrentRawGameTime);
    public int CurrentRawGameTime { get; set; }
    public List<string> Items { get; set; } = new List<string>();
    
    // Transient State
    public bool MapTravelAllowed { get; set; } = true;
    
    // Permanent Inventory
    public List<string> Blueprints { get; set; }

    public GameState WithTime(int time)
    {
        CurrentRawGameTime = time;
        return this;
    }
    
    public GameState WithResetTransients()
        => new GameState
        {
            Blueprints = Blueprints
        };
}
