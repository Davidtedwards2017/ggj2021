using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

public class CustomerQueue : MonoBehaviour
{
    public CustomerAssetsSO Customers;
    private FilteredRandom<CustomerSO> random;

    public GameObject NextCustomer;
    public GameObject CurrentCustomer;

    public Transform NextCustomerContainer;
    public Transform CurrentCustomerContainer;

    public VoidEventChannelSO OnGameStartEvent;
    public VoidEventChannelSO CustomerWalkUpStartEvent;
    public VoidEventChannelSO CustomerWalkAwayEndEvent;
    
    // Start is called before the first frame update
    void Start()
    {
        random = new FilteredRandom<CustomerSO>(Customers.Assets, 1);
    }

    public void OnEnable()
    {
        OnGameStartEvent.OnEventRaised += ReadyCurrentCustomer;
        CustomerWalkUpStartEvent.OnEventRaised += ReadyNextCustomer;
        CustomerWalkAwayEndEvent.OnEventRaised += OnCustomerWalkedAway;
    }

    public void OnDisable()
    {
        OnGameStartEvent.OnEventRaised -= ReadyCurrentCustomer;
        CustomerWalkUpStartEvent.OnEventRaised -= ReadyNextCustomer;
        CustomerWalkAwayEndEvent.OnEventRaised -= OnCustomerWalkedAway;
    }

    private void OnCustomerWalkedAway()
    {
        ClearContainer(CurrentCustomerContainer);
        ReadyCurrentCustomer();
    }

    private void ReadyCurrentCustomer()
    {
        if (NextCustomer != null)
        {
            CurrentCustomer = NextCustomer;
            NextCustomer = null;

            CurrentCustomer.transform.SetParent(CurrentCustomerContainer);
            CurrentCustomer.SetLocalPosition(Vector3.zero);
            CurrentCustomer.transform.localScale = Vector3.one;
            CurrentCustomer.GetComponent<CustomerAnimations>().enabled = true;
        }
        else if (CurrentCustomer == null)
        {
            ClearContainer(CurrentCustomerContainer);
            CurrentCustomer = Instantiate(random.GetNextRandom().Prefab, CurrentCustomerContainer);
        }
    }

    private void ReadyNextCustomer()
    {
        if (NextCustomer == null)
        {
            ClearContainer(NextCustomerContainer);
            NextCustomer = Instantiate(random.GetNextRandom().Prefab, NextCustomerContainer);
            NextCustomer.GetComponent<CustomerAnimations>().enabled = false;
        }
    }

    private void ClearContainer(Transform container)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }


}
