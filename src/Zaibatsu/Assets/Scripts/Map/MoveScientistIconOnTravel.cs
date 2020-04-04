
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class MoveScientistIconOnTravel : OnMessage<BeganTravellingToLocation, ArrivedAtLocation>
{
    private RectTransform _t;

    private void Awake() => _t = GetComponent<RectTransform>();
    
    protected override void Execute(BeganTravellingToLocation msg)
    {
    }

    protected override void Execute(ArrivedAtLocation msg) => _t.anchoredPosition = msg.Location.GeoPosition;
}