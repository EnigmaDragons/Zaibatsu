using UnityEngine;

[CreateAssetMenu]
public class CalendarGlobalEventAsset : ScriptableObject
{
    [SerializeField] private string description;
    [SerializeField] private string startTime;
    [SerializeField] private string endTime;
    [SerializeField] private TextAsset sequence;

    public CalendarGlobalEvent AsEvent() => new CalendarGlobalEvent
    {
        Description = description,
        StartTime = startTime,
        EndTime = endTime,
        SequenceName = sequence.name
    };
}
