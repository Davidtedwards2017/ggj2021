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
    }

    public void OnDisable()
    {
        StartVisionEvent.OnEventRaised -= OnVisionStart;
        StopVisionEvent.OnEventRaised -= OnVisionStop;
        ReagentClickedEventSO.Event.RemoveListener(ReagentClicked);
        ReagentDestroyedEventSO.Event.RemoveListener(OnReagentDestroyed);
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

    private void ReagentClicked(ReagentClickedEventData args)
    {
        if (args.ClickedReagent != this) return;
        SpawnGrabbedInstance();

        SetActive(false);
    }

    private GrabbedReagent SpawnGrabbedInstance()
    {
        var instance = Instantiate(GrabbedReagentPrefab, transform.position, transform.rotation);
        instance.name = GrabbedReagentPrefab.name;
        instance.reagentData = reagentData;
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void OnClicked()
    {
        SpawnGrabbedInstance();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
