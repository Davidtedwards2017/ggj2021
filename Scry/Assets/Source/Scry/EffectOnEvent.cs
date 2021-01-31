using UnityEngine;

public class EffectOnEvent : MonoBehaviour
{
    public VoidEventChannelSO ActivationEvent;
    public ShakeEffectDataSO EffectData;

    public void OnEnable()
    {
        ActivationEvent.OnEventRaised += StartEffect;
    }

    public void OnDisable()
    {
        ActivationEvent.OnEventRaised -= StartEffect;
    }

    public void StartEffect()
    {
        if (EffectData != null)
        {
            EffectData.PerformEffect(transform);
        }
    }
}
