using Spooky.Utilities.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleVision : MonoBehaviour
{
    public ParticleEmissionController VisionEffectEmissionCtrl;
    public float TimeBeforeVision = 1.0f;
    public float TimeOfVision = 1.0f;
    public float TimeAfterVision = 1.0f;

    public float EmissionRate = 20;

    public ShowFoundResultEventSO ShowFoundResultEvent;

    public IEnumerator StartVision()
    {
        VisionEffectEmissionCtrl.Emission = EmissionRate;
        yield return new WaitForSeconds(TimeBeforeVision);
        yield return new WaitForSeconds(TimeOfVision);
        ShowFoundResultEvent.RaiseEvent(new ShowFoundResultEventData() { });
        VisionEffectEmissionCtrl.Emission = 0;
        yield return new WaitForSeconds(TimeAfterVision);
    }
}
