
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class MoveScientistIconOnTravel : OnMessage<BeganTravellingToLocation, ArrivedAtLocation>
{
    [SerializeField] private CurrentLocation current;
    [SerializeField] private Floating floating;
    
    private RectTransform _t;

    private void Awake() => _t = GetComponent<RectTransform>();
    private void OnEnable() => MoveTo(current.Location);
    
    protected override void Execute(BeganTravellingToLocation msg) {}
    protected override void Execute(ArrivedAtLocation msg) => MoveTo(msg.Location);
    
    private void MoveTo(Location l)
    {
        floating.enabled = false;
        _t.anchoredPosition = l.GeoPosition;
        floating.enabled = true;
    }
}