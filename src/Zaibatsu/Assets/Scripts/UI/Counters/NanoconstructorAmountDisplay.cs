using TMPro;
using UnityEngine;

public sealed class NanoconstructorAmountDisplay : OnMessage<GameStateChanged>
{
    [SerializeField] private CurrentGameState state;
    [SerializeField] private TextMeshProUGUI counter;

    private void Awake() => UpdateText(state.Current.NumNanoconstructors);
    protected override void Execute(GameStateChanged msg) => UpdateText(msg.State.NumNanoconstructors);
    private void UpdateText(int numNanos) => counter.text = numNanos.ToString();
}
