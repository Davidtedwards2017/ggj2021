using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidEventAccess : MonoBehaviour
{
    public VoidEventChannelSO Event;

    public void Invoke()
    {
        Event.RaiseEvent();
    }
}
