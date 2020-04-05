using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ChoiceSelectionView : MonoBehaviour
{
    [SerializeField, AssetsOnly] private ChoiceButton buttonPrototype;
    [SerializeField] private GameObject buttonParent;
    [SerializeField] private CurrentSequence seq;
    
    private readonly ChoiceButton[] _buttons = new ChoiceButton[8];

    private List<Choice> _choices;
    
    public void SetChoices(List<Choice> choices)
    {
        _choices = choices;
        for (var i = 0; i < 8; i++)
        {
            if (_buttons[i] == null)
                _buttons[i] = Instantiate(buttonPrototype, buttonParent.transform);
            if (i < choices.Count)
            {
                var choiceIndex = i;
                _buttons[i].Init($"{i + 1}. {choices[i].Text}", () => SelectChoice(choiceIndex));
            }
            else
                _buttons[i].gameObject.SetActive(false);
        }
    }

    public void SelectChoice(int index)
    {
        gameObject.SetActive(false);
        seq.PickChoice(_choices[index].NextID);
    }
}
