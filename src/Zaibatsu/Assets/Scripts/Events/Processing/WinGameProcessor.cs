using UnityEngine;

public class WinGameProcessor : OnMessage<WinGame>
{
    [SerializeField] private Navigator navigator;

    protected override void Execute(WinGame msg) => navigator.NavigateToVictoryScene();
}
