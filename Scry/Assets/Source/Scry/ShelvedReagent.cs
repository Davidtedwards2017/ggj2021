using Spooky.Utilities.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelvedReagent : MonoBehaviour
{
    public ReagentSO reagentData;

    public ReagentClickedEventSO ReagentClickedEventSO;
    public ReagantDestroyEventSO ReagentDestroyedEventSO;
    public GrabbedReagent GrabbedReagentPrefab;

    public VoidEventChannelSO StartVisionEvent;
    public VoidEventChannelSO StopVisionEvent;

    public GameObject EnabledVisual;
    public GameObject DisableVisual;
    public Collider2D Collider;

    public ReagentGrabEventSO GrabReagentEvent;
    public RecipeEventSO RecipeEvent;

    public EffectData SparkleEffect;
    private GameObject SparkleEffectInstance;

    public ReagentEnteredCauldrenEventSO ReagentEnteredCauldrenEvent;

    private void Awake()
    {
        SetActive(true);
    }

    public void OnEnable()
    {
        StartVisionEvent.OnEventRaised += OnVisionStart;
        StopVisionEvent.OnEventRaised += OnVisionStop;
        ReagentClickedEventSO.Event.AddListener(ReagentClicked);
        ReagentDestroyedEventSO.Event.AddListener(OnReagentDestroyed);
        RecipeEvent.OnRaiseEvent.AddListener(OnRecipeEvent);
        ReagentEnteredCauldrenEvent.Event.AddListener(OnReagentEnteredCauldron);
    }

    public void OnDisable()
    {
        StartVisionEvent.OnEventRaised -= OnVisionStart;
        StopVisionEvent.OnEventRaised -= OnVisionStop;
        ReagentClickedEventSO.Event.RemoveListener(ReagentClicked);
        ReagentDestroyedEventSO.Event.RemoveListener(OnReagentDestroyed);
        RecipeEvent.OnRaiseEvent.RemoveListener(OnRecipeEvent);
        ReagentEnteredCauldrenEvent.Event.RemoveListener(OnReagentEnteredCauldron);
    }

    private void OnVisionStart()
    {
        SetActive(false);
    }

    private void OnVisionStop()
    {
        SetActive(true);
    }

    private void OnReagentDestroyed(ReagentDestroyEventData args)
    {
        if (args.Reagent.reagentData == reagentData)
        {
            SetActive(true);
        }
    }

    public void SetActive(bool value)
    {
        Collider.enabled = value;
        EnabledVisual.SetActive(value);
        DisableVisual.SetActive(!value);
    }

    private void OnRecipeEvent(RecipeEventData args)
    {
        SetSparkle(args.Reagents.Contains(reagentData));
    }

    private void SetSparkle(bool active)
    {
        if (active)
        {
            SparkleEffectInstance = SparkleEffect.Spawn(transform.position, transform);
        }
        else
        {
            SparkleEffectInstance.Fizzle(0);
        }
    }

    private void OnReagentEnteredCauldron(ReagentEnteredCauldrenEventData args)
    {
        if (args.Reagent.reagentData == reagentData)
        {
            SetSparkle(false);
        }
    }

    private void ReagentClicked(ReagentClickedEventData args)
    {
        if (args.ClickedReagent != this) return;

        GrabReagentEvent.RaiseEvent(SpawnGrabbedInstance(args.HitInfo));
        SetActive(false);
    }

    private GrabbedReagent SpawnGrabbedInstance(RaycastHit2D hitInfo)
    {
        var instance = Instantiate(GrabbedReagentPrefab, transform.position, transform.rotation);
        instance.name = GrabbedReagentPrefab.name;
        instance.reagentData = reagentData;
        instance.Hit = hitInfo;
        instance.gameObject.SetActive(true);

        return instance;
    }
}
