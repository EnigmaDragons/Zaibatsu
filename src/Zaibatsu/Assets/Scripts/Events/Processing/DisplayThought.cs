using UnityEngine;

public class DisplayThought : OnMessage<ThinkToSelf>
{
    [SerializeField] private ThoughtView view;

    protected override void Execute(ThinkToSelf msg)
    {
        view.Set(msg.Thought);
        view.gameObject.SetActive(true);
    }
}
