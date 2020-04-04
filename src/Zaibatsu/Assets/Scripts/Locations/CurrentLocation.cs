using UnityEngine;

[CreateAssetMenu]
public sealed class CurrentLocation : ScriptableObject
{
    [SerializeField] private Location location;

    public Location Location => location;

    public void SetLocation(Location newLocation)
    {
        location = newLocation;
        Message.Publish(new CurrentLocationChanged(location));
    }
}
