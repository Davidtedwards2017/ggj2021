using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShelvedReagent : MonoBehaviour
{
    public ReagentSO reagentData;

    public ReagentClickedEventSO ReagentClickedEventSO;
    public GrabbedReagent GrabbedReagentPrefab;

    public void OnEnable()
    {
        ReagentClickedEventSO.Event.AddListener(ReagentClicked);
    }

    public void OnDisable()
    {
        ReagentClickedEventSO.Event.RemoveListener(ReagentClicked);
    }

    private void ReagentClicked(ReagentClickedEventData args)
    {
        if (args.ClickedReagent != this) return;
        SpawnGrabbedInstance();
    }


    private GrabbedReagent SpawnGrabbedInstance()
    {
        var instance = Instantiate(GrabbedReagentPrefab, transform.position, transform.rotation);
        instance.name = GrabbedReagentPrefab.name;
        instance.gameObject.SetActive(true);

        return instance;
    }

    public void OnClicked()
    {
        SpawnGrabbedInstance();
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
