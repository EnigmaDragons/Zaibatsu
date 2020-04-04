using TMPro;
using UnityEngine;

public sealed class CreditsAmountDisplay : OnMessage<GameStateChanged>
{
    [SerializeField] private CurrentGameState state;
    [SerializeField] private TextMeshProUGUI counter;

    private void Awake() => UpdateText(state.Current.NumCredits);
    protected override void Execute(GameStateChanged msg) => UpdateText(msg.State.NumCredits);
    private void UpdateText(int numCredits) => counter.text = numCredits.ToString();
}