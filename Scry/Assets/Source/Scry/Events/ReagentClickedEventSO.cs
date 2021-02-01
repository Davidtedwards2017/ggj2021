using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Reagent Clicked")]
public class ReagentClickedEventSO : ScriptableObject
{
    public SfxAsset Sfx;

    public ReagentClickedEvent Event = new ReagentClickedEvent();
    public void Raise(ReagentClickedEventData args)
    {
        if (Event != null)
        {
            Event.Invoke(args);
        }

        if (Sfx != null)
        {
            Sfx.Play();
        }
    }
}

[System.Serializable]
public class ReagentClickedEventData
{
    public ShelvedReagent ClickedReagent;
    public RaycastHit2D HitInfo;
}

public class ReagentClickedEvent : UnityEvent<ReagentClickedEventData> { }