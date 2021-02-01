using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

[System.Serializable, CreateAssetMenu(menuName = "Audio/Sfx Group")]
public class SfxGroupSO : SfxAsset
{
    public List<SfxSO> SFXs;

    public override void Play()
    {
        SFXs.PickRandom().Play();
    }

}
