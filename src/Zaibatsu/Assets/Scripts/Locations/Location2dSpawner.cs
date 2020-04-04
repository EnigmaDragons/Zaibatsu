
using System.Collections.Generic;
using UnityEngine;

public class Location2dSpawner : OnMessage<BeganTravellingToLocation>
{
    [SerializeField] private CurrentGameMap map;

    private readonly Dictionary<string, GameObject> _locations = new Dictionary<string, GameObject>();
    
    private void Start() => Spawn(map.CurrentLocation);

    protected override void Execute(BeganTravellingToLocation msg) => Spawn(msg.Destination);

    private void Spawn(Location location)
    {
        foreach (var l in _locations) 
            l.Value.SetActive(false);
        
        if (_locations.TryGetValue(location.DisplayName, out var cached))
            cached.SetActive(true);
        else
            _locations[location.DisplayName] = Instantiate(location.LocationPrefab, transform);
        _locations[location.DisplayName].transform.SetAsFirstSibling();
    }
}
