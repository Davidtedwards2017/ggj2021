using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimations : MonoBehaviour
{
    public Animator Animator;

    public VoidEventChannelSO StartWalkingUpEvent;
    public VoidEventChannelSO ShowCustomerReqeustEvent;
    public VoidEventChannelSO HideCustomerRequestEvent;


    public VoidEventChannelSO SuccessfulBrewEvent;
    public VoidEventChannelSO UnsuccessfulBrewEvent;

    private void OnEnable()
    {
        StartWalkingUpEvent.OnEventRaised += Idle;
        HideCustomerRequestEvent.OnEventRaised += Idle;
        ShowCustomerReqeustEvent.OnEventRaised += Request;

        SuccessfulBrewEvent.OnEventRaised += Happy;
        UnsuccessfulBrewEvent.OnEventRaised += Mad;
    }

    private void OnDisable()
    {
        StartWalkingUpEvent.OnEventRaised -= Idle;
        HideCustomerRequestEvent.OnEventRaised -= Idle;
        ShowCustomerReqeustEvent.OnEventRaised -= Request;

        SuccessfulBrewEvent.OnEventRaised -= Happy;
        UnsuccessfulBrewEvent.OnEventRaised -= Mad;
    }

    private void Idle()
    {
        Animator.SetTrigger("idle");
    }

    private void Request()
    {
        Animator.SetTrigger("request");
    }

    private void Happy()
    {
        Animator.SetTrigger("happy");
    }

    private void Mad()
    {
        Animator.SetTrigger("mad");
    }
}
