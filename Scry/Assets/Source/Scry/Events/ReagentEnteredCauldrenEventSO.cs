using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Reagent Entered Cauldron")]
public class ReagentEnteredCauldrenEventSO : ScriptableObject
{
    public ReagentEnteredCauldrenEvent Event = new ReagentEnteredCauldrenEvent();
    public void Raise(ReagentEnteredCauldrenEventData args)
    {
        if (Event != null)
        {
            Event.Invoke(args);
        }
    }
}
[System.Serializable]
public class ReagentEnteredCauldrenEventData
{
    public GrabbedReagent Reagent;
    public Cauldron Cauldron;
}

public class ReagentEnteredCauldrenEvent : UnityEvent<ReagentEnteredCauldrenEventData> { }
