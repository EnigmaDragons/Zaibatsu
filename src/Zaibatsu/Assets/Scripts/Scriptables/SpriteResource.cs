using UnityEngine;

[CreateAssetMenu(fileName = "Sprite Resource", menuName = "Resources")]
public class SpriteResource : ScriptableObject
{
    [SerializeField] private Sprite sprite;

    public Sprite Sprite => sprite;
}