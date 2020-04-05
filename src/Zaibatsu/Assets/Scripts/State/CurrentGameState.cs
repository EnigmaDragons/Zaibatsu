using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

[CreateAssetMenu]
public class CurrentGameState : SerializedScriptableObject 
{
    [OdinSerialize] private GameState gameState = new GameState();
    [SerializeField] private GameDayStartState dayStart;
    [SerializeField] private CurrentGameMap gameMap;
    [SerializeField] private CurrentGameCalendar calendar;
    [SerializeField] private int numCredits;
    [SerializeField] private int numNanoconstructors;
    [SerializeField] private string time;
    [SerializeField] private CurrentSequence sequence;
    [SerializeField] private Variables variables;
    [SerializeField] private Location currentLocation;
    [SerializeField] private List<Item> items;
    [SerializeField] private List<Blueprint> blueprints;

    public GameState State  => gameState;
    public Location CurrentLocation => currentLocation;
    public GameTime Time => gameState.Time;

    public void Init()
    {
        items = new List<Item>();
        blueprints = new List<Blueprint>();
        variables.Init();
        calendar.Init();
        Message.Subscribe<CurrentLocationChanged>(msg => currentLocation = msg.Location, this);
        
        gameMap.Init();
        sequence.Name = dayStart.gameStartSequence;
        UpdateState(gs => new GameState { CurrentRawGameTime = dayStart.GameStartTimeMinutes });
    }

    public void Reset()
    {
        items = new List<Item>();
        blueprints = new List<Blueprint>();
        calendar.Reset();
        gameMap.Reset();
        sequence.Name = dayStart.gameStartSequence;
        UpdateState(gs => gs.WithResetTransients().WithTime(dayStart.GameStartTimeMinutes));
    }

    public void AddBlueprint(Blueprint blueprint)
    {
        blueprints.Add(blueprint);
        UpdateState(gs => gs.Blueprints.Add(blueprint.DisplayName));
    }

    public void RemoveBlueprint(Blueprint blueprint)
    {
        blueprints.Remove(blueprint);
        UpdateState(gs => gs.Blueprints.Remove(blueprint.DisplayName));
    }
    
    public void AddItem(Item item)
    {
        items.Add(item);
        UpdateState(gs => gs.Items.Add(item.DisplayName));
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        UpdateState(gs => gs.Items.Remove(item.DisplayName));
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

    public bool IsItemPresent(string item) => gameState.Items.Contains(item);
}
