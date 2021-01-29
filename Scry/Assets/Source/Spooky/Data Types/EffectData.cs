using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Effect Data")]
public class EffectData : ScriptableObject
{
    public GameObject Prefab;
    public float FizzleDuration = 0.5f;
    public float Duration;
    public Vector3 Offset;
    public bool OverrideColor = false;
    public Color Color;
}
