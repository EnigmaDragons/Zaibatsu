using System.Collections;
using UnityEngine;

public sealed class Clock : MonoBehaviour
{
    [SerializeField] private GameObject hourHand;
    [SerializeField] private GameObject minuteHand;
    [SerializeField] private bool autoRun;
    [SerializeField] private float secondsPerGameMinute = 0.5f;
    [SerializeField, ReadOnly] private int currentMinutes = 0;
    [SerializeField, ReadOnly] private int currentHours = 0;
    
    private int _timeMinutes = 0;

    private void Awake()
    {
        if (autoRun)
            StartCoroutine(AutoRun());
    }

    private IEnumerator AutoRun()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsPerGameMinute);
            AdvanceMinutes(1);
        }
    }
    
    public void AdvanceMinutes(int numMinutes)
    {
        _timeMinutes += numMinutes;
        currentMinutes = _timeMinutes % 60;
        currentHours = _timeMinutes / 60;
    }
    
    private void FixedUpdate()
    {
        var mHandRot = minuteHand.transform.localRotation;
        minuteHand.transform.localRotation = Quaternion.Euler(mHandRot.x, _timeMinutes * 6f, mHandRot.y);
        var hHandRot = hourHand.transform.localRotation;
        hourHand.transform.localRotation = Quaternion.Euler(hHandRot.x, _timeMinutes * 0.5f, mHandRot.y);
    }
}