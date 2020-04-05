using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu]
public class CurrentGameState : SerializedScriptableObject 
{
    [OdinSerialize] private GameState gameState = new GameState();
    [SerializeField] private GameDayStartState dayStart;
    [SerializeField] private CurrentGameMap gameMap;
    [SerializeField] private int numCredits;
    [SerializeField] private int numNanoconstructors;
    [SerializeField] private string time;
    [SerializeField] private CurrentSequence sequence;
    [SerializeField] private Variables variables;
    [SerializeField] private Location currentLocation;

    public GameState State  => gameState;
    
    public void Init()
    {
        variables.Init();
        Message.Subscribe<CurrentLocationChanged>(msg => currentLocation = msg.Location, this);
        
        gameMap.Init();
        sequence.Name = dayStart.gameStartSequence;
        UpdateState(_ => new GameState { CurrentRawGameTime = dayStart.GameStartTimeMinutes });
    }

    public void Reset()
    {
        gameMap.Reset();
        sequence.Name = dayStart.gameStartSequence;
        UpdateState(_ => new GameState { CurrentRawGameTime = dayStart.GameStartTimeMinutes });
    }
    
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
        gameState = apply(gameState);
        numCredits = gameState.NumCredits;
        numNanoconstructors = gameState.NumNanoconstructors;
        time = gameState.Time.Time;
        Message.Publish(new GameStateChanged(gameState));
    }
}
