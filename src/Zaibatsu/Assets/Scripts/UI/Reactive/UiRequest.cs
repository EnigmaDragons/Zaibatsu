using UnityEngine;

public class UiRequest : MonoBehaviour
{
    [SerializeField] private GameUiElement element;
    [SerializeField] private UiCommand command;

    public void SendRequest()
    {
        Message.Publish(new ChangeUiElementStateRequested(element, command));
    }
}
