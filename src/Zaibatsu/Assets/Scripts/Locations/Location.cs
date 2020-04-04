using UnityEngine;

[CreateAssetMenu]
public sealed class Location : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private string description;
    [SerializeField] private Vector2 geoPosition;
    [SerializeField] private GameObject locationPrefab;

    public string DisplayName => displayName;
    public string Description => description;
    public Vector2 GeoPosition => geoPosition;
    public GameObject LocationPrefab => locationPrefab;
}