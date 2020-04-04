public class GameStateChanged
{
    public GameState State { get; }

    public GameStateChanged(GameState newState) => State = newState;
}