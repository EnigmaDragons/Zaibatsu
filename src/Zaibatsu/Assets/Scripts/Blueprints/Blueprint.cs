using UnityEngine;

[CreateAssetMenu]
public class Blueprint : ScriptableObject
{
    [SerializeField] private string displayName;
    [SerializeField] private int nanoConstructorsRequired;
    [SerializeField] private Item[] itemsRequired;
    [SerializeField] private Item resultItem;

    public string DisplayName => displayName;
    public int NanoConstructorsRequired => nanoConstructorsRequired;
    public Item[] ItemsRequired => itemsRequired;
    public Item ResultItem => resultItem;
}