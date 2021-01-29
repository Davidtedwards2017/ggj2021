using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Effect")]
public class EffectSO : ScriptableObject
{
    //public GameObject Prefab;
    public float FizzleDuration = 0.5f;
    public float Duration;
    public Vector3 Offset;
    public bool OverrideColor = false;
    public Color Color;
}
