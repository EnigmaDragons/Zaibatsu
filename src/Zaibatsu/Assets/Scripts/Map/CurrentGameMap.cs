using UnityEngine;

[CreateAssetMenu]
public class CurrentGameMap : ScriptableObject
{
    [SerializeField] private GameMap map;
    public Location[] Locations => map.Locations;
    public Location StartingLocation => map.StartingLocation;
}
