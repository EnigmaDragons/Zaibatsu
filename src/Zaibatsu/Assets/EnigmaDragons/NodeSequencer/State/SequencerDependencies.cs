using UnityEngine;

public class SequencerDependencies : ScriptableObject
{
    public IMediaType MediaType => new JsonMediaType();
}