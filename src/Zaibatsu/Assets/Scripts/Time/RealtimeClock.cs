using System.Collections;
using UnityEngine;

public sealed class RealtimeClock : MonoBehaviour
{
    [SerializeField] private CurrentGameState state;
    [SerializeField] private float secondsPerGameMinute = 0.5f;
    
    private void Awake() => StartCoroutine(AutoRun());

    private IEnumerator AutoRun()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsPerGameMinute);
            state.UpdateState(gs => gs.CurrentRawGameTime += 1);
        }
    }
}
