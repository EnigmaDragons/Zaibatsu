using UnityEngine;

public class MapAccessProcessor : OnMessage<AllowMapTravel, DisableMapTravel>
{
    [SerializeField] private CurrentGameState game;

    protected override void Execute(AllowMapTravel msg)
    {
        game.UpdateState(gs => gs.MapTravelAllowed = true);
        Message.Publish(new SequenceStepFinished());
    }

    protected override void Execute(DisableMapTravel msg)
    {
        game.UpdateState(gs => gs.MapTravelAllowed = false);
        Message.Publish(new SequenceStepFinished());
    } 
}