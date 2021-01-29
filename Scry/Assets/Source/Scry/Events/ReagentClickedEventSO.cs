using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Reagent Clicked")]
public class ReagentClickedEventSO : ScriptableObject
{
    public ReagentClickedEvent Event = new ReagentClickedEvent();
    public void Raise(ReagentClickedEventData args)
    {
        if (Event != null)
        {
            Event.Invoke(args);
        }
    }
}

[System.Serializable]
public class ReagentClickedEventData
{
    public ShelvedReagent ClickedReagent;
}

public class ReagentClickedEvent : UnityEvent<ReagentClickedEventData> { }