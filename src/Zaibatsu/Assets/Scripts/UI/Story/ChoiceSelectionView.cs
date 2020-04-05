using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ChoiceSelectionView : MonoBehaviour
{
    [SerializeField, AssetsOnly] private ChoiceButton buttonPrototype;
    [SerializeField] private CurrentSequence seq;
    
    private readonly ChoiceButton[] _buttons = new ChoiceButton[8];
    
    public void SetChoices(List<Choice> choices)
    {
        for (var i = 0; i < 8; i++)
        {
            if (_buttons[i] == null)
                _buttons[i] = Instantiate(buttonPrototype, transform);
            if (i < choices.Count)
                _buttons[i].gameObject.SetActive(false);
            else
            {
                var choice = choices[i];
                _buttons[i].Init(choice.Text, () => seq.PickChoice(choice.NextID));
            }
        }
    }
}
