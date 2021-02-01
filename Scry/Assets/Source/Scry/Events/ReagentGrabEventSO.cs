using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Grab Reagent Event")]
public class ReagentGrabEventSO : ScriptableObject
{
    public ReagentGrabEvent OnEventRaised = new ReagentGrabEvent();
    public void RaiseEvent(GrabbedReagent reagent)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(reagent);
        }
    }
}

public class ReagentGrabEvent : UnityEvent<GrabbedReagent> { }