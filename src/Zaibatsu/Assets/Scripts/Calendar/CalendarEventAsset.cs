using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu]
public class CalendarEventAsset : SerializedScriptableObject
{
    [SerializeField] private Location location;
    [SerializeField] private string description;
    [SerializeField] private string startTime;
    [SerializeField] private string endTime;
    [SerializeField] private TextAsset sequence;
    [SerializeField] private bool isRecurring;

    public CalendarEvent AsEvent() => new CalendarEvent
    {
        Location = location,
        Description = description,
        StartTime = startTime,
        EndTime = endTime,
        SequenceName = sequence.name,
        IsRecurring = isRecurring
    };
}
