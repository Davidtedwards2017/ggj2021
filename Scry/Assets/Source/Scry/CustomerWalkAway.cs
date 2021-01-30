using UnityEngine;

public class CustomerWalkAway : MonoBehaviour
{
    public const string TRIGGER_NAME = "WalkAway";

    public VoidEventChannelSO StartWalkAwayEvent;
    public VoidEventChannelSO StopWalkAwayEvent;

    public Animator Animator;

    public void OnEnable()
    {
        StartWalkAwayEvent.OnEventRaised += StartWalkingAway;
    }

    public void OnDisable()
    {
        StartWalkAwayEvent.OnEventRaised -= StartWalkingAway;
    }

    private void StartWalkingAway()
    {
        Animator.SetTrigger(TRIGGER_NAME);
    }

    public void DoneWalkingAway()
    {
        StopWalkAwayEvent.RaiseEvent();
    }
}
