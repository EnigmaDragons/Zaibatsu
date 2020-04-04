using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu]
public class CurrentGameState : SerializedScriptableObject 
{
    [OdinSerialize] private GameState gameState = new GameState();
    [SerializeField] private int numCredits;
    [SerializeField] private int numNanoconstructors;
    [SerializeField] private string time;

    public GameState State  => gameState;
    
    public void Init() => UpdateState(_ => new GameState());

    public void UpdateState(Action<GameState> apply)
    {
        UpdateState(_ =>
        {
             apply(gameState);
             return gameState;
        });
    }
    
    public void UpdateState(Func<GameState, GameState> apply)
    {
        apply(gameState);
        numCredits = gameState.NumCredits;
        numNanoconstructors = gameState.NumNanoconstructors;
        time = gameState.Time.Time;
        Message.Publish(new GameStateChanged(gameState));
    }
}
