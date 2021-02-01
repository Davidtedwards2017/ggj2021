using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Mouse")]
public class MouseEventSO : ScriptableObject
{
    public MouseEvent OnRaisedEvent = new MouseEvent();

    public void RaiseEvent(MouseEventData args)
    {
        if (OnRaisedEvent != null)
        {
            OnRaisedEvent.Invoke(args);
        }
    }
}

public class MouseEventData 
{
    public GameObject GameObject;
}

public class MouseEvent : UnityEvent<MouseEventData> { }
