using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShutterEffect : MonoBehaviour
{
    public VoidEventChannelSO ActivationEvent;
    public PunchEffectDataSO PunchPositionSettings;
    public PunchEffectDataSO PunchRotationSettings;

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
        if (PunchPositionSettings != null)
        {
            PunchPositionSettings.PerformPunchPosition(transform);
        }

        if (PunchRotationSettings != null)
        {
            PunchRotationSettings.PerformPunchRotation(transform);
        }
    }

    

}
