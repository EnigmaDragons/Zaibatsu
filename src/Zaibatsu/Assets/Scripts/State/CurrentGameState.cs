﻿using System;
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
    [SerializeField] private Choices choices;
    [SerializeField] private List<Item> items;

    public GameState State  => gameState;
    public Location CurrentLocation => currentLocation;
    public GameTime Time => gameState.Time;

    public void Init()
    {
        items = new List<Item>();
        variables.Init();
        calendar.Init();
        Message.Subscribe<CurrentLocationChanged>(msg => currentLocation = msg.Location, this);
        
        gameMap.Init();
        sequence.Name = dayStart.gameStartSequence;
        UpdateState(_ => new GameState { CurrentRawGameTime = dayStart.GameStartTimeMinutes });
    }

    public void Reset()
    {
        items = new List<Item>();
        calendar.Reset();
        gameMap.Reset();
        choices.IsShowing = false;
        sequence.Name = dayStart.gameStartSequence;
        UpdateState(_ => new GameState { CurrentRawGameTime = dayStart.GameStartTimeMinutes });
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
