using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class SequenceOrchestrator : MonoBehaviour
{
    [SerializeField] private List<TextAsset> sequences;
    [SerializeField] private CurrentSequence currentSequence;

    private readonly IMediaType _mediaType = new JsonMediaType();

    private SequenceData _sequence;

    private void OnEnable()
    {
        Message.Subscribe<SequenceStateChanged>(Execute, this);
        Message.Subscribe<SequenceStepFinished>(Execute, this);
        if (!string.IsNullOrWhiteSpace(currentSequence.Name))
            _sequence = _mediaType.ConvertFrom<SequenceData>(sequences.First(x => x.name == currentSequence.Name).text);
    }

    private void Execute(SequenceStateChanged msg)
    {
        if (currentSequence.IsActive)
        {
            currentSequence.ShouldEnd = false;
            _sequence = _mediaType.ConvertFrom<SequenceData>(sequences.First(x => x.name == currentSequence.Name).text);
            ProcessStep(_sequence.Steps.First(x => x.ID == _sequence.StartID));
        }
    }

    protected void Execute(SequenceStepFinished msg)
    {
        if (currentSequence.ShouldEnd)
        {
            currentSequence.IsActive = false;
            Message.Publish(new SequenceStateChanged());
        }
        else
            ProcessStep(_sequence.Steps.First(x => x.ID == currentSequence.NextStepID));
    }

    private void ProcessStep(SequenceStepData step)
    {
        currentSequence.CurrentStepID = step.ID;
        //TODO
    }
}