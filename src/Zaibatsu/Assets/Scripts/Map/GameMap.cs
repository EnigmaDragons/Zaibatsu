using UnityEngine;

[CreateAssetMenu]
public sealed class GameMap : ScriptableObject
{
    [SerializeField] private Location[] locations;
    [SerializeField] private int startingLocationIndex = 0;
    
    public Location[] Locations => locations;
    public Location StartingLocation => locations[startingLocationIndex];
}