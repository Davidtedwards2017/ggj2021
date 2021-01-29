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

    public void Awake()
    {
        contactFilter2D = new ContactFilter2D();
        raycastResultsBuffer = new RaycastHit2D[5];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            var count = Physics2D.Raycast(mousePos2D, Vector2.zero, contactFilter2D, raycastResultsBuffer);
            for (int i = 0; i <= count; i++)
            {
                var hit = raycastResultsBuffer[i];
                if (hit.collider != null)
                {
                    if (hit.transform.tag.Equals(GameSettingSO.TAG_REAGENT))
                    {
                        var reagent = hit.transform.GetComponentInParent<ShelvedReagent>();
                        ClickReagent(reagent);
                    }
                }
            }
        }
    }

    void ClickReagent(ShelvedReagent reagent)
    {
        ReagentClickedEvent.Raise(new ReagentClickedEventData() 
        {
            ClickedReagent = reagent 
        });
    }
}
