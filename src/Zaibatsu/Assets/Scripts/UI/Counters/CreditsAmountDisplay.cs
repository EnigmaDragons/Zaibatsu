
public sealed class CreditsAmountDisplay : GameReactiveUiText
{
    protected override string GetValue(GameState game) => game.NumCredits.ToString();
}