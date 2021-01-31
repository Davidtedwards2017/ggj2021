using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class CustomerRequest : MonoBehaviour
{
    public VoidEventChannelSO ShowCustomerRequestEvent;
    public VoidEventChannelSO HideCustomerRequestEvent;

    private const string SHOW_REQUEST = "ShowRequest";
    public Animator Animator;

    private FilteredRandom<LostItemSO> random;

    public LostItemsAssets LostItems;
    public Transform LostItemContainer;

    private void Awake()
    {
        random = new FilteredRandom<LostItemSO>(LostItems.Assets, 3);
    }

    private void OnEnable()
    {
        ShowCustomerRequestEvent.OnEventRaised += OnShowCustomerRequest;
        HideCustomerRequestEvent.OnEventRaised += OnHideCustomerRequestDialogue;
    }

    private void OnDisable()
    {
        ShowCustomerRequestEvent.OnEventRaised -= OnShowCustomerRequest;
        HideCustomerRequestEvent.OnEventRaised -= OnHideCustomerRequestDialogue;
    }

    private void OnShowCustomerRequest()
    {
        foreach (Transform child in LostItemContainer)
        {
            Destroy(child.gameObject);
        }


        var asset = random.GetNextRandom();

        Instantiate(asset.Prefab, LostItemContainer);

        Animator.SetBool(SHOW_REQUEST, true);
    }

    private void OnHideCustomerRequestDialogue()
    {
        Animator.SetBool(SHOW_REQUEST, false);
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
