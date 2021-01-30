using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnEvent : MonoBehaviour
{
    public VoidEventChannelSO EnableEvent;
    public VoidEventChannelSO DisableEvent;

    public Behaviour[] behaviors;

    private void Awake()
    {
        //behaviors = GetComponents<Behaviour>();
    }

    private void OnEnable()
    {
        EnableEvent.OnEventRaised += OnEnableEvent;
        DisableEvent.OnEventRaised += OnDisableEvent;
    }

    private void OnDisable()
    {
        EnableEvent.OnEventRaised -= OnEnableEvent;
        DisableEvent.OnEventRaised -= OnDisableEvent;
    }

    private void OnEnableEvent()
    {
        SetActive(true);
    }

    private void OnDisableEvent()
    {
        SetActive(false);
    }

    public void SetActive(bool value)
    {
        foreach (var behaviour in behaviors)
        {
            behaviour.enabled = value;
        }
    }

}
