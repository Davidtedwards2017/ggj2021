using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scry/Cauldorn State")]
public class CauldronStateSO : ScriptableObject
{
    public EffectData StateEffect;
    public float BubbleEmissionRate;
    public AudioClip Audio;
    [Range(0,1)]
    public float AudioVolume = 1;


}
