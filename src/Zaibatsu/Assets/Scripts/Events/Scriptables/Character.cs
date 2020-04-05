using UnityEngine;

[CreateAssetMenu(menuName = "Resources/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private string name;

    public string Name => name;
}