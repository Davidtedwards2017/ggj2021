using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentPicker : MonoBehaviour
{
    public GameSettingSO Settings;
    public ReagentClickedEventSO ReagentClickedEvent;
    public LayerMask layerMask;

    ContactFilter2D contactFilter2D;
    RaycastHit2D[] raycastResultsBuffer;

    public MouseEventSO OnMouseEnterEvent;
    public MouseEventSO OnMouseLeaveEvent;

    private List<GameObject> mousedOverLastFrame = new List<GameObject>();

    public void Awake()
    {
        contactFilter2D = new ContactFilter2D();
    }


    // Update is called once per frame
    void Update()
    {
        var mousedOveredThisFrame = new List<GameObject>();
        bool clicked = Input.GetMouseButtonDown(0);

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        raycastResultsBuffer = new RaycastHit2D[5];
        var count = Physics2D.Raycast(mousePos2D, Vector2.zero, contactFilter2D, raycastResultsBuffer);
        for (int i = 0; i <= count; i++)
        {
            var hit = raycastResultsBuffer[i];
            if (hit.collider != null)
            {
                if (clicked)
                {
                    if (hit.transform.tag.Equals(GameSettingSO.TAG_REAGENT))
                    {
                        var reagent = hit.transform.GetComponentInParent<ShelvedReagent>();
                        ClickReagent(reagent, hit);
                    }
                }

                mousedOveredThisFrame.Add(hit.collider.gameObject);
            }
        }

        foreach (var g in mousedOveredThisFrame)
        {
            if(!mousedOverLastFrame.Contains(g))
            {
                OnMouseEnterEvent.RaiseEvent(new MouseEventData() { GameObject = g });
            }
        }

        foreach (var g in mousedOverLastFrame)
        {
            if (!mousedOveredThisFrame.Contains(g))
            {
                OnMouseLeaveEvent.RaiseEvent(new MouseEventData() { GameObject = g });
            }
        }


        mousedOverLastFrame = mousedOveredThisFrame;
    }

    void ClickReagent(ShelvedReagent reagent, RaycastHit2D hit)
    {
        ReagentClickedEvent.Raise(new ReagentClickedEventData() 
        {
            ClickedReagent = reagent,
            HitInfo = hit
        });
    }
}
