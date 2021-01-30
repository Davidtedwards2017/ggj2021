using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip StartingMusic;
    public AudioClip LoopingMusic;

    public VoidEventChannelSO GameStartEvent;

    private void OnEnable()
    {
        GameStartEvent.OnEventRaised += OnGameStart;
    }

    private void OnDisable()
    {
        GameStartEvent.OnEventRaised -= OnGameStart;
    }

    public void OnGameStart()
    {
        MusicController.Instance.Play(LoopingMusic);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
