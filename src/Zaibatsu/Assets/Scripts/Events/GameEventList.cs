using System;

public static class GameEventList
{
    //A bit hacky
    public static Type[] Types = new Type[]
    {
        typeof(StoryPictureShown),
        typeof(NarratorStated),
        typeof(PlayerDied),
        typeof(CharacterStated),
        typeof(LocationArrived),
    };
}