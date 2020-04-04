
public sealed class DigitalClock : GameReactiveUiText
{
    protected override string GetValue(GameState game) => game.Time.ToString();
}