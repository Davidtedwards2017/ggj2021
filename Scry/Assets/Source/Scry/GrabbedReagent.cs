using UnityEngine;

public class GrabbedReagent : MonoBehaviour
{
    public ReagentSO reagentData;
    public ReagentEnteredCauldrenEventSO ReagentEnteredCauldrenEvent;
    public ReagantDestroyEventSO DestroyReagentEvent;

    public RaycastHit2D Hit;

    private void OnEnable()
    {
        DestroyReagentEvent.Event.AddListener(OnDestroyReagent);
    }

    private void OnDisable()
    {
        DestroyReagentEvent.Event.RemoveListener(OnDestroyReagent);
    }

    private void OnDestroyReagent(ReagentDestroyEventData args)
    {
        if (args.Reagent == this)
        {
            Destroy(gameObject);
        }
    }

    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.tag.Equals(GameSettingSO.TAG_CAULDRON))
    //    {
    //        var cauldron = GetComponentInParent<Cauldron>();
    //        ReagentEnteredCauldrenEvent.Raise(new ReagentEnteredCauldrenEventData()
    //        {
    //            Reagent = this,
    //            Cauldron = cauldron
    //        });
    //    }
    //}
}
