using UnityEngine;

public class ModifyResourcesProcessor : OnMessage<ModifyResources>
{
    [SerializeField] private CurrentGameState game;

    protected override void Execute(ModifyResources msg) => game.UpdateState(gs =>
    {
        gs.NumCredits += msg.CreditsAdjustment;
        gs.NumNanoconstructors += msg.NanoConstructorsAdjustment;
    });
}
