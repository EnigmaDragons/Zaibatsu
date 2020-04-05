using UnityEngine;

public class ChoicesGivenProcessor : OnMessage<ChoicesGiven>
{
    [SerializeField] private CurrentChoices current;
    [SerializeField] private ChoiceSelectionView view;

    protected override void Execute(ChoicesGiven msg)
    {
        view.SetChoices(current.List);
        view.gameObject.SetActive(true);
    }
}
