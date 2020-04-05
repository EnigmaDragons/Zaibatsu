
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button button;
    
    private Action _onSelect;

    private void Awake() => button.onClick.AddListener(Select);
    
    public void Init(string text, Action onSelect)
    {
        _onSelect = onSelect;
        label.text = text;
        gameObject.SetActive(true);
    }

    public void Select()
    {
        _onSelect();
    }
}
