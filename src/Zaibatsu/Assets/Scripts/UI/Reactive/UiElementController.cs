
using UnityEngine;

public sealed class UiElementController : OnMessage<ChangeUiElementStateRequested>
{
    [SerializeField] private GameUiElement element;
    [SerializeField] private GameObject obj;

    private bool _preLockState;
    private bool _isLocked = false;

    protected override void Execute(ChangeUiElementStateRequested msg)
    {
        if (msg.Element != element)
            return;
        
        if (_isLocked && msg.Command != UiCommand.Unlock)
            return;
        if (msg.Command == UiCommand.Lock)
        {
            _preLockState = obj.activeSelf;
            _isLocked = true;
            obj.SetActive(false);
        }

        if (msg.Command == UiCommand.Unlock)
        {
            _isLocked = false;
            obj.SetActive(_preLockState);
        }
        
        if (msg.Command == UiCommand.Hide)
            obj.SetActive(false);
        if (msg.Command == UiCommand.Show)
            obj.SetActive(true);
        if (msg.Command == UiCommand.Toggle)
            obj.SetActive(!obj.activeSelf);
    }
}