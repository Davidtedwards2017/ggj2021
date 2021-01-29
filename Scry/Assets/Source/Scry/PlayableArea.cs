using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableArea : MonoBehaviour
{
    public ReagantDestroyEventSO DestroyReagentEvent;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals(GameSettingSO.TAG_REAGENT))
        {
            var reagent = other.GetComponentInParent<GrabbedReagent>();
            DestroyReagentEvent.Raise(new ReagentDestroyEventData()
            {
                Reagent = reagent
            });
        }
    }
}
