
public sealed class NanoconstructorAmountDisplay : GameReactiveUiText
{
    protected override string GetValue(GameState game) => game.NumNanoconstructors.ToString();
}
