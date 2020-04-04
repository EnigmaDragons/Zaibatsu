using UnityEngine;

[CreateAssetMenu]
public sealed class Location : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private string description;
    [SerializeField] private Vector2 geoPosition;
}