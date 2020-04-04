using UnityEngine;

public class SpriteResource : ScriptableObject
{
    [SerializeField] private Sprite sprite;

    public Sprite Sprite => sprite;
}