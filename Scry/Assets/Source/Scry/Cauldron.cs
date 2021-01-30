using Spooky.Utilities.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;
using DG.Tweening;

public class Cauldron : MonoBehaviour
{
    public VoidEventChannelSO StartVisionEvent;
    public VoidEventChannelSO StopVisionEvent;

    public VoidEventChannelSO BrewingStartEvent;
    public VoidEventChannelSO BrewingStopEvent;

    public ReagentEnteredCauldrenEventSO ReagentEnteredCauldrenEvent;
    public ReagantDestroyEventSO ReagentDestroyEvent;

    public EffectData SpashEffect;
    public ParticleEmissionController BubblingEffectEmissionCtrl;

    public BubbleVision BubbleVision;

    private int stateIndex = 0;
    public CauldronStateSO[] States;
    public List<ReagentSO> AddedReagent;

    public float FadeOutDuration = 0.5f;


    private void OnEnable()
    {
        BrewingStartEvent.OnEventRaised += StartBrewing;
    }

    private void OnDisable()
    {
        BrewingStartEvent.OnEventRaised -= StartBrewing;
    }

    private void StartBrewing()
    {
        AddedReagent = new List<ReagentSO>();
        stateIndex = 0;
        NextState();
    }

    private void StopBrewing()
    {
        BrewingStopEvent.RaiseEvent();
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
        StartCoroutine(BubbleVisionSequence());
    }

    private IEnumerator BubbleVisionSequence()
    {
        StartVisionEvent.RaiseEvent();
        yield return BubbleVision.StartVision();
        FadeOutCurrentAudio();
        SetBubbleEmissionRate(0);
        StopVisionEvent.RaiseEvent();
        StopBrewing();
    }

    AudioSource currentAudio;
    private void OnEnteredState(CauldronStateSO state)
    {
        FadeOutCurrentAudio();
        SetBubbleEmissionRate(state.BubbleEmissionRate);

        if (state.Audio != null)
        {
            currentAudio = AudioHelper.PlaySfx(state.Audio, state.AudioVolume, true);
        }
    }

    private void FadeOutCurrentAudio()
    {
        if (currentAudio != null)
        {
            var temp = currentAudio;
            currentAudio = null;
            temp.DOFade(0, FadeOutDuration).OnComplete(() => Destroy(temp.gameObject));
        }
    }

    private void SetBubbleEmissionRate(float rate)
    {
        BubblingEffectEmissionCtrl.Emission = rate;
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
