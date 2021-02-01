using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReagentAnimator : MonoBehaviour
{
    public MouseEventSO MouseEnterEvent;
    public MouseEventSO MouseLeaveEvent;
    public Animator Animator;

    private bool mouseHover = false;

    private void OnEnable()
    {
        MouseEnterEvent.OnRaisedEvent.AddListener(MouseEnter);
        MouseLeaveEvent.OnRaisedEvent.AddListener(MouseLeave);
    }

    private void OnDisable()
    {
        MouseEnterEvent.OnRaisedEvent.RemoveListener(MouseEnter);
        MouseLeaveEvent.OnRaisedEvent.RemoveListener(MouseLeave);
    }
    

    public void MouseEnter(MouseEventData args)
    {
        if (args.GameObject != gameObject) return;

        Animator.SetBool("hover", true);
    }

    public void MouseLeave(MouseEventData args)
    {
        if (args.GameObject != gameObject) return;

        Animator.SetBool("hover", false);

    }
}
