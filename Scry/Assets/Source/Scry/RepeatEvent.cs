using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatEvent : MonoBehaviour
{
    public VoidEventChannelSO Event;
    public float RepeatDelay = 2;
    
    private void OnEnable()
    {
        StartCoroutine(Sequence());
    }

    private void OnDisable()
    {
        StopCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        while (true)
        {
            yield return new WaitForSeconds(RepeatDelay);
            Event.RaiseEvent();
        }
    }
}
