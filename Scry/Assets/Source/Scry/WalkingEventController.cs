using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEventController : MonoBehaviour
{
    public VoidEventChannelSO StopWalkingUpEvent;
    public VoidEventChannelSO StopWalkingAwayEvent;

    public SfxAsset StepSfx;

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
        if (StepSfx != null)
        {
            StepSfx.Play();
        }
    }
}
