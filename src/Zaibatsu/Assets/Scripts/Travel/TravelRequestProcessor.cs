using UnityEngine;

public class TravelRequestProcessor : OnMessage<GoToLocation>
{
    [SerializeField] private CurrentGameMap map;

    protected override void Execute(GoToLocation msg)
    {
        if (map.CanTravelTo(msg.Location))
            Message.Publish(new BeganTravellingToLocation(map.CurrentLocation, msg.Location));
    }
}
