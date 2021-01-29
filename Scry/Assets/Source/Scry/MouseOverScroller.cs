using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverScroller : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 ScrollDirection;
    public Vector3EventSO ScrollEvent;

    private bool MouseOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOver = false;
    }

    public void Update()
    {
        if (MouseOver)
        {
            ScrollEvent.Raise(ScrollDirection);
        }
    }
}
