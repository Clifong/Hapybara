using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayExecution : MonoBehaviour
{
    public CrossObjectEvent timerEnd;
    public int time;

    public void StartTimer() {
        StartCoroutine(Timer());
    }

    private IEnumerator Timer() {
        yield return new WaitForSeconds(time);
        timerEnd.TriggerEvent();
    }
}
