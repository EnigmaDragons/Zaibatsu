using UnityEngine;

public sealed class MapSpawner : MonoBehaviour
{
    [SerializeField] private CurrentGameMap map;
    [SerializeField] private MapLocationNode nodePrototype;
    [SerializeField] private GameObject scientistPrototype;

    private void Awake()
    {
        map.Locations.ForEach(SpawnNode);
        SpawnScientist();
    }

    private void SpawnNode(Location l)
    {
        var o = Instantiate(nodePrototype, transform);
        var rectTransform = o.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = l.GeoPosition;
        o.Init(map, l);
    }

    private void SpawnScientist()
    {
        var o = Instantiate(scientistPrototype, transform);
        var rectTransform = o.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = map.StartingLocation.GeoPosition;
        var floating = o.GetComponent<Floating>();
        if (floating != null)
            floating.enabled = true;
    }
}