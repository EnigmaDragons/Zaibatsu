using UnityEngine;

[CreateAssetMenu]
public sealed class GameMap : ScriptableObject
{
    [SerializeField] private Location[] locations;
}