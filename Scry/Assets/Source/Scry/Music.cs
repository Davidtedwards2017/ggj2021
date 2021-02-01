using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class Music : MonoBehaviour
{
    public AudioClip StartingMusic;
    public AudioClip LoopingMusic;

    public VoidEventChannelSO GameStartEvent;

    //private void OnEnable()
    //{
    //    GameStartEvent.OnEventRaised += OnGameStart;
    //}
    //
    //private void OnDisable()
    //{
    //    GameStartEvent.OnEventRaised -= OnGameStart;
    //}

    public void OnGameStart()
    {


    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MusicSequence());
    }

    private IEnumerator MusicSequence()
    {
        //yield return new WaitForSeconds(1);
        var startingMusicLength = StartingMusic.length;
        MusicController.Instance.Play(StartingMusic);
        yield return new WaitForSeconds(startingMusicLength);
        MusicController.Instance.Play(LoopingMusic);
    }
}
