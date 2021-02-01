using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleCard : MonoBehaviour
{
    public GameSettingSO Settings;
    public VoidEventChannelSO StartGameEvent;

    public float EndPosition;
    public float MoveDuration = 2.0f;

    public RectTransform RectTransform;



    // Update is called once per frame
    void Update()
    {
        if (Settings.GameStarted) return;

        if (Input.anyKeyDown)
        {
            StartGameEvent.RaiseEvent();
            RectTransform.DOMoveY(EndPosition, MoveDuration).SetRelative(true);
        }
    }

}
