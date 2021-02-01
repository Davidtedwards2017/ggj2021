using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public List<SfxAsset> SFXs;

    public UnityAction OnEventRaised;
    public void RaiseEvent()
    {
        if (OnEventRaised != null)
        {
            OnEventRaised.Invoke();
        }

        foreach(var sfx in SFXs)
        {
            sfx.Play();
        }
    }
}