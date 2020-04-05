using System;

public static class GameEventList
{
    //A bit hacky
    public static Type[] Types = new Type[]
    {
        typeof(ShowStoryImage),
        typeof(ShowNarratorStatement),
        typeof(KillPlayer),
        typeof(ShowCharacterStatement),
        typeof(GoToLocation),
    };
}