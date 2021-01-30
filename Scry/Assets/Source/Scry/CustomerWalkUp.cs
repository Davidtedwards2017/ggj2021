using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerWalkUp : MonoBehaviour
{
    public const string TRIGGER_NAME = "WalkUp";

    public VoidEventChannelSO StartWalkUpEvent;
    public VoidEventChannelSO StopWalkUpEvent;

    public Animator Animator;

    public void OnEnable()
    {
        StartWalkUpEvent.OnEventRaised += StartWalkingUp;
    }

    public void OnDisable()
    {
        StartWalkUpEvent.OnEventRaised -= StartWalkingUp;
    }

    private void StartWalkingUp()
    {
        Animator.SetTrigger(TRIGGER_NAME);
    }

    public void DoneWalkingUp()
    {
        StopWalkUpEvent.RaiseEvent();
    }

}
