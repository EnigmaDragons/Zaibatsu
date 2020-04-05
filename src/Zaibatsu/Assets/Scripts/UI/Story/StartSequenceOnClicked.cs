using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartSequenceOnClicked : MonoBehaviour
{
    [SerializeField] private CurrentSequence seq;
    [SerializeField] private TextAsset asset;

    public void Awake() 
        => GetComponent<Button>().onClick.AddListener(
            () => seq.ChangeSequence(asset.name));
}