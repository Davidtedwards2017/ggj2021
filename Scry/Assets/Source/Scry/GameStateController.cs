using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    public enum State
    {
        none,
        starting,
        customerwalkingup,
        brewing,
        customerwalkingaway,
    }

    public VoidEventChannelSO GameStartEvent;
    
    public VoidEventChannelSO CustomerWalkUpStartEvent;
    public VoidEventChannelSO CustomerWalkUpStopEvent;

    public VoidEventChannelSO CustomerWalkAwayStartEvent;
    public VoidEventChannelSO CustomerWalkAwayStopEvent;

    public VoidEventChannelSO BrewingStartEvent;
    public VoidEventChannelSO BrewingStopEvent;

    public State CurrentState;

    // Start is called before the first frame update
    void Start()
    {
        SetState(State.starting);
    }

    // Update is called once per frame
    private void Update()
    {
        switch (CurrentState)
        {
            case State.starting:
                SetState(State.customerwalkingup);
                break;
        }
    }

    private void OnEnable()
    {
        CustomerWalkUpStopEvent.OnEventRaised += OnStoppedWalkingUp;
        CustomerWalkAwayStopEvent.OnEventRaised += OnStoppedWalkingAway;
        BrewingStopEvent.OnEventRaised += OnStoppedBrewing;
    }

    private void OnDisable()
    {
        CustomerWalkUpStopEvent.OnEventRaised -= OnStoppedWalkingUp;
        CustomerWalkAwayStopEvent.OnEventRaised -= OnStoppedWalkingAway;
        BrewingStopEvent.OnEventRaised -= OnStoppedBrewing;
    }

    private void SetState(State state)
    {
        if (CurrentState == state) return;
                
        LeaveState(CurrentState);
        
        CurrentState = state;
        EnterState(state);
    }

    private void EnterState(State state)
    {
        switch (state) 
        {
            case State.starting:
                GameStartEvent.RaiseEvent();
                break;
            case State.customerwalkingup:
                CustomerWalkUpStartEvent.RaiseEvent();
                break;
            case State.brewing: 
                BrewingStartEvent.RaiseEvent();
                break;
            case State.customerwalkingaway: 
                CustomerWalkAwayStartEvent.RaiseEvent();
                break;
        }

        return;
    }

    private void LeaveState(State state)
    {
        switch (state)
        {
            case State.starting:
                break;
            case State.customerwalkingup:
                break;
            case State.brewing:
                break;
            case State.customerwalkingaway:
                break;
        }

        return;
    }

    private void OnStoppedWalkingUp()
    {
        SetState(State.brewing);
    }

    private void OnStoppedBrewing()
    {
        SetState(State.customerwalkingaway);
    }

    private void OnStoppedWalkingAway()
    {
        SetState(State.customerwalkingup);
    }


}
