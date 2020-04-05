
using UnityEngine;

public class MapAccessController : OnMessage<GameStateChanged>
{
    [SerializeField] private GameObject mapAccess;
    
    protected override void Execute(GameStateChanged msg) => mapAccess.SetActive(msg.State.MapTravelAllowed);
}
