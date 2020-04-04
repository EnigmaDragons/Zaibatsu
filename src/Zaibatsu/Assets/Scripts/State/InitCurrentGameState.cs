using UnityEngine;

public class InitCurrentGameState : MonoBehaviour
{
    [SerializeField] private CurrentGameState state;

    void Awake() => state.Init();
}
