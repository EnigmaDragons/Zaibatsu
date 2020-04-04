
    using UnityEngine;

    public class DisableDuringTravel : OnMessage<BeganTravellingToLocation, ArrivedAtLocation>
    {
        [SerializeField] private MonoBehaviour script;
        
        protected override void Execute(BeganTravellingToLocation msg) => script.enabled = false;

        protected override void Execute(ArrivedAtLocation msg) => script.enabled = true;
    }