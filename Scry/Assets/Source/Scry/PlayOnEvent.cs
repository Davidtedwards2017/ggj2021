using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEvent : MonoBehaviour
{
    public SfxAsset SoundsEffect;
    public VoidEventChannelSO Event;

    private void OnEnable()
    {
        Event.OnEventRaised += OnEvent;
    }

    private void OnDisable()
    {
        Event.OnEventRaised -= OnEvent;
    }

    public void OnEvent()
    {
        SoundsEffect.Play();    
    }

}
