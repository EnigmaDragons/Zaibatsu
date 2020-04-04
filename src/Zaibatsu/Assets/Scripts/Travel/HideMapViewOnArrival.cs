using System.Collections;
using UnityEngine;

public sealed class HideMapViewOnArrival : OnMessage<ArrivedAtLocation>
{
    [SerializeField] private float delayBeforeHiding = 1f;

    protected override void Execute(ArrivedAtLocation msg) => StartCoroutine(HideAfterDelay());

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeHiding);
        Message.Publish(new ChangeUiElementStateRequested(GameUiElement.MapView, UiCommand.Hide));
    }
}
