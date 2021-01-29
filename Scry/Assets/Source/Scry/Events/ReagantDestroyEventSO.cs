using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Reagent Destroy")]
public class ReagantDestroyEventSO : ScriptableObject
{
    public ReagentDestroyEvent Event = new ReagentDestroyEvent();
    public void Raise(ReagentDestroyEventData args)
    {
        if (Event != null)
        {
            Event.Invoke(args);
        }
    }
}

[System.Serializable]
public class ReagentDestroyEventData
{
    public GrabbedReagent Reagent;
}

public class ReagentDestroyEvent : UnityEvent<ReagentDestroyEventData> { }