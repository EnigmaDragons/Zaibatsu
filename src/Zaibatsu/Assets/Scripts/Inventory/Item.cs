using UnityEngine;

[CreateAssetMenu]
public sealed class Item : ScriptableObject
{
    [SerializeField] private Sprite image;
    [SerializeField] private string displayName;

    public Sprite Image => image;
    public string DisplayName => displayName;
}