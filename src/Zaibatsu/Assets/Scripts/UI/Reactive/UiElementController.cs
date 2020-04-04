
using UnityEngine;

public sealed class UiElementController : OnMessage<ChangeUiElementStateRequested>
{
    [SerializeField] private GameUiElement element;
    [SerializeField] private GameObject obj;

    protected override void Execute(ChangeUiElementStateRequested msg)
    {
        if (msg.Element != element)
            return;
        
        var showElement = false;
        if (msg.Command == UiCommand.Hide)
            showElement = false;
        if (msg.Command == UiCommand.Show)
            showElement = true;
        if (msg.Command == UiCommand.Toggle)
            showElement = !obj.activeSelf;
        obj.SetActive(showElement);
    }
}