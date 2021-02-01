using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

[System.Serializable, CreateAssetMenu(menuName = "Audio/Sfx")]
public class SfxSO : SfxAsset
{
    public AudioClip Clip;
    [Range(0,1)]
    public float BaseVolume = 1;

    public override void Play()
    {
        AudioHelper.PlaySfx(Clip, BaseVolume);
    }
}
