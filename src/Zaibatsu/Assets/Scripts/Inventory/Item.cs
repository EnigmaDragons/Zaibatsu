using UnityEngine;

[CreateAssetMenu]
public sealed class Item : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private string displayName;

    public string DisplayName => displayName;
}