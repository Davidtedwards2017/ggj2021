using Spooky.Utilities.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    public ReagentEnteredCauldrenEventSO ReagentEnteredCauldrenEvent;
    public ReagantDestroyEventSO ReagentDestroyEvent;

    public EffectData SpashEffect;
    public ParticleEmissionController BubblingEffectEmissionCtrl;

    public BubbleVision BubbleVision;

    private int stateIndex = 0;
    public CauldronStateSO[] States;
    public List<ReagentSO> AddedReagent;


    private void Reset()
    {
        AddedReagent = new List<ReagentSO>();
    }

    private void OnEnable()
    {
        OnEnteredState(States[stateIndex = 0]);
        //ReagentEnteredCauldrenEvent.Event.AddListener(OnReagentEnteredCauldron);
    }

    private void OnDisable()
    {
        //ReagentEnteredCauldrenEvent.Event.RemoveListener(OnReagentEnteredCauldron);
    }

    private void NextState()
    {
        var currentState = States[stateIndex++];
        OnEnteredState(currentState);

        if (stateIndex >= States.Length)
        {
            stateIndex = 0;
            LastState(currentState);
            //this is last state;
        }
    }

    private void LastState(CauldronStateSO state)
    {
        StartCoroutine(BubbleVision.StartVision());
        NextState();
    }
        
    private void OnEnteredState(CauldronStateSO state)
    {
        Debug.Log("Entered State " + state.name);
        BubblingEffectEmissionCtrl.Emission = state.BubbleEmissionRate;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals(GameSettingSO.TAG_REAGENT))
        {
            var reagent = other.GetComponentInParent<GrabbedReagent>();
            ReagentEnteredCauldrenEvent.Raise(new ReagentEnteredCauldrenEventData()
            {
                Reagent = reagent,
                Cauldron = this
            });

            ReagentDestroyEvent.Raise(new ReagentDestroyEventData()
            {
                Reagent = reagent
            });


            SpashEffect.Spawn(other.transform.position);

            NextState();
        }
    }
}
