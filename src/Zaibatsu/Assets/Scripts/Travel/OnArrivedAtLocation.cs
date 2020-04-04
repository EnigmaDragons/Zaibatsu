using UnityEngine;
using UnityEngine.Events;

public sealed class OnArrivedAtLocation : OnMessage<ArrivedAtLocation>
{
    [SerializeField] private UnityAction action;
    
    protected override void Execute(ArrivedAtLocation msg) => action();
}
