using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Sprite")]
public class SpriteResource : ScriptableObject
{
    [SerializeField] private Sprite sprite;

    public Sprite Sprite => sprite;
}