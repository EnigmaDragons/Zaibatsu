using UnityEngine;

public class ArriveInstantly : OnMessage<BeganTravellingToLocation>
{
    [SerializeField] private CurrentLocation location;
    
    protected override void Execute(BeganTravellingToLocation msg)
    {
        location.SetLocation(msg.Destination);
        Message.Publish(new ArrivedAtLocation(msg.Destination));
    }
}