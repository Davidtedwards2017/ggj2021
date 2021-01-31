using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Show Found Result Event")]
public class ShowFoundResultEventSO : ScriptableObject
{
    public ShowFoundResultEvent OnEventRaised = new ShowFoundResultEvent();

    public void RaiseEvent(ShowFoundResultEventData args)
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke(args);
        }
    }
}

public class ShowFoundResultEventData
{

}

public class ShowFoundResultEvent : UnityEvent<ShowFoundResultEventData> { }
