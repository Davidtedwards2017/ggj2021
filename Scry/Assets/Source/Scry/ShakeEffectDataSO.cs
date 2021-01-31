using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Scry/Effects/Shake Effect Data")]
public class ShakeEffectDataSO : ScriptableObject
{
    public float Duration = 1;
    public float Strength = 1;
    public int Vibro = 10;
    public float Randomness = 90;
    public bool FadeOut = false;

    public Ease Ease = Ease.Linear;

    public void PerformEffect(Transform t)
    {
        t.DOShakePosition(
                Duration,
                Strength,
                Vibro,
                Randomness,
                FadeOut)
            .SetEase(Ease);
    }
}
