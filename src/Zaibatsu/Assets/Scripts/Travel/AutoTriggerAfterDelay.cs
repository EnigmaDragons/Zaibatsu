using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AutoTriggerAfterDelay : MonoBehaviour
{
    [SerializeField] private float delaySeconds = 1f;
    [SerializeField] private UnityEvent action;

    private void OnEnable() => StartCoroutine(ExecuteAfterDelay());

    private IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        action.Invoke();
    }
}