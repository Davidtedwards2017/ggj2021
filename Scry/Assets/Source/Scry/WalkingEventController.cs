using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEventController : MonoBehaviour
{
    public VoidEventChannelSO StopWalkingUpEvent;
    public VoidEventChannelSO StopWalkingAwayEvent;

    public void StopWalkingUp()
    {
        StopWalkingUpEvent.RaiseEvent();
    }

    public void StopWalkingAway()
    {
        StopWalkingAwayEvent.RaiseEvent();
    }

    public void Step()
    {

    }
}
