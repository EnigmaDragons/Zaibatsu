using TMPro;
using UnityEngine;

public abstract class LocationReactiveUiText : OnMessage<CurrentLocationChanged>
{
    [SerializeField] private CurrentLocation current;
    [SerializeField] private TextMeshProUGUI ui;

    private void Start() => ui.text = GetValue(current.Location);

    protected abstract string GetValue(Location location);
    protected override void Execute(CurrentLocationChanged msg) => ui.text = GetValue(msg.Location);
}