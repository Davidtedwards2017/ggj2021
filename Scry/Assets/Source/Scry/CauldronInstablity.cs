using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Spooky.Utilities.Effects;

public class CauldronInstablity : MonoBehaviour
{
    public VoidEventChannelSO InsabilityEvent;
    public VoidEventChannelSO ExplosionEvent;

    public Vector3 ExplosionEffectOffset;
    public EffectData ExplosionEffect;

    public Shake ShakeEffect;
    public Ease ShakingEase = Ease.Linear;
    public float MaxShakeMagnitude = 1;

    public float BuildUpDuration = 3.0f;
    public float RampDownDuration = 1.0f;

    public IEnumerator Sequence()
    {
        InsabilityEvent.RaiseEvent();
        StartShaking();
        yield return new WaitForSeconds(BuildUpDuration);
        ExplosionEffect.Spawn(transform.position + ExplosionEffectOffset);
        ExplosionEvent.RaiseEvent();
        yield return new WaitForSeconds(RampDownDuration);
    }

    private void StartShaking()
    {
        ShakeEffect.shakeMagnitude = 0;
        DOTween.To(
            () => ShakeEffect.shakeMagnitude,
            x => ShakeEffect.shakeMagnitude = x,
            MaxShakeMagnitude,
            BuildUpDuration)
        .SetEase(ShakingEase)
        .OnComplete(
            () => ShakeEffect.shakeMagnitude = 0);
    }
}
