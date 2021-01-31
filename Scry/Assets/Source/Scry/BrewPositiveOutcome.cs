using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Utilites;

public class BrewPositiveOutcome : MonoBehaviour
{
    public ShowFoundResultEventSO ShowFoundResultEvent;

    public CanvasGroup CanvasGroup;

    public OutcomeAssetsSO Outcomes;

    private FilteredRandom<OutcomeSO> random;

    public Transform OutcomeContainer;

    public float ShowDuration = 1.0f;
    public float FadeDuration = 0.5f;

    void Awake()
    {
        random = new FilteredRandom<OutcomeSO>(Outcomes.Assets, 2);

        CanvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        ShowFoundResultEvent.OnEventRaised.AddListener(OnShowFoundResultEvent);
    }

    private void OnDisable()
    {
        ShowFoundResultEvent.OnEventRaised.RemoveListener(OnShowFoundResultEvent);
    }

    private void OnShowFoundResultEvent(ShowFoundResultEventData args)
    {
        StartCoroutine(OutcomeSequence());
    }

    private IEnumerator OutcomeSequence()
    {
        ClearContainer();
        SpawnOutcome(random.GetNextRandom());

        CanvasGroup.DOFade(1, FadeDuration);
        yield return new WaitForSeconds(ShowDuration);
        CanvasGroup.DOFade(0, FadeDuration);
    }

    private void SpawnOutcome(OutcomeSO outcome)
    {
        Instantiate(outcome.prefab, OutcomeContainer);
    }

    private void ClearContainer()
    {
        foreach (Transform child in OutcomeContainer)
        {
            Destroy(child.gameObject);
        }
    }

}
