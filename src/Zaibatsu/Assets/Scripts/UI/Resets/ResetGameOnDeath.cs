
using System.Collections;
using UnityEngine;

public class ResetGameOnDeath : OnMessage<KillPlayer>
{
    [SerializeField] private FloatReference delayBeforeReset;

    protected override void Execute(KillPlayer msg) => StartCoroutine(Reset());
    public void Execute() => StartCoroutine(Reset()); 
    
    private IEnumerator Reset()
    {
        Message.Publish(new ChangeUiElementStateRequested(GameUiElement.DiedView, UiCommand.Show));
        yield return new WaitForSeconds(delayBeforeReset);
        Message.Publish(new ResetDay());
    }
}
