﻿using System;

public static class GameEventList
{
    //A bit hacky
    public static Type[] Types = new Type[]
    {
        typeof(ShowStoryImage),
        typeof(KillPlayer),
        typeof(ShowCharacterStatement),
        typeof(GoToLocation),
        typeof(ThinkToSelf),
        typeof(TalkToCharacter),
        typeof(StopTalking),
        typeof(AllowMapTravel),
        typeof(DisableMapTravel),
        typeof(GainItem),
        typeof(LoseItem),
        typeof(ModifyResources),
        typeof(GainBlueprint),
        typeof(RevealLocation),
        typeof(SpendTime),
        typeof(WinGame),
        typeof(AddCalendarEvent),
    };
}