using UnityEngine;

[CreateAssetMenu]
public class CurrentGameMap : ScriptableObject
{
    [SerializeField] private GameMap map;
    [SerializeField] private CurrentLocation currentLocation;
    
    public Location[] Locations => map.Locations;
    public Location StartingLocation => map.StartingLocation;
    public Location CurrentLocation => currentLocation.Location;

    public void Init() => currentLocation.SetLocation(StartingLocation);
    
    public bool CanTravelTo(Location destination) => CanTravel(currentLocation.Location, destination);
    public bool CanTravel(Location source, Location destination) => true;
}
