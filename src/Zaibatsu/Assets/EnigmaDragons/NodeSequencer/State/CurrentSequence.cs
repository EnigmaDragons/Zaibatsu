﻿using UnityEngine;

[CreateAssetMenu]
public class CurrentSequence : ScriptableObject
{
    public string Name;
    public string CurrentStepID;
    public string NextStepID;
    public bool IsActive;
    public bool ShouldEnd;
    public bool IsDebug;

    public void StartSequence(string name)
    {
        Name = name;
        IsActive = true;
        Message.Publish(new SequenceStateChanged());
    }
}