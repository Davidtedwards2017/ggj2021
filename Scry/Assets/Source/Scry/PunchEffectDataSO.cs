using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(menuName = "Scry/Effects/Punch Effect Data")]
public class PunchEffectDataSO : ScriptableObject
{
    public float DurationMin = 0.5f;
    public float DurationMax = 1f;
        
    public float PunchXMin = -1;
    public float PunchXMax = 1;

    public float PunchYMin = -1;
    public float PunchYMax = 1;

    public float PunchZMin = -1;
    public float PunchZMax = 1;

    public int Vibro = 10;
    public float Elasticity = 1;
    public Ease Ease = Ease.Linear;

    private Vector3 GetPunch()
    {
        var x = Random.Range(PunchXMin, PunchXMax);
        var y = Random.Range(PunchYMin, PunchYMax);
        var z = Random.Range(PunchZMin, PunchZMax);

        return new Vector3(x, y, z);
    }

    public void PerformPunchPosition(Transform t)
    {
        var punch = GetPunch();
        var duration = Random.Range(DurationMin, DurationMax);

        t.DOPunchPosition(
                punch,
                duration,
                Vibro,
                Elasticity)
            .SetEase(Ease);
    }

    public void PerformPunchRotation(Transform t)
    {
        var punch = GetPunch();
        var duration = Random.Range(DurationMin, DurationMax);

        t.DOPunchRotation(
                punch,
                duration,
                Vibro,
                Elasticity)
            .SetEase(Ease);
    }
}
