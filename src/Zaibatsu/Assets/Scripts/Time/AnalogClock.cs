using UnityEngine;

public sealed class AnalogClock : OnMessage<GameStateChanged>
{
    [SerializeField] private CurrentGameState game;
    [SerializeField] private GameObject hourHand;
    [SerializeField] private GameObject minuteHand;
    
    private int _timeMinutes = 0;

    private void Awake() => _timeMinutes = game.State.CurrentRawGameTime;
    protected override void Execute(GameStateChanged msg) => _timeMinutes = msg.State.CurrentRawGameTime;
    
    private void FixedUpdate()
    {
        var mHandRot = minuteHand.transform.localRotation;
        minuteHand.transform.localRotation = Quaternion.Euler(mHandRot.x, _timeMinutes * 6f, mHandRot.y);
        var hHandRot = hourHand.transform.localRotation;
        hourHand.transform.localRotation = Quaternion.Euler(hHandRot.x, _timeMinutes * 0.5f, mHandRot.y);
    }
}
