using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilites;

public class Recipe : MonoBehaviour
{
    public GameSettingSO Settings;
    public ReagentAssets Reagents;
    public int Size = 3;
    public int RandomHistoryLength = 3;

    public VoidEventChannelSO UpdateRecipeEvent;

    public List<ReagentSO> CurrentRecipe;

    private FilteredRandom<ReagentSO> filteredRandom;

    public RecipeEventSO RecipeEvent;

    public void Awake()
    {
        filteredRandom = new FilteredRandom<ReagentSO>(Reagents.Assets, RandomHistoryLength);
    }

    private void OnEnable()
    {
        UpdateRecipeEvent.OnEventRaised += UpdateRecipe;
    }

    private void OnDisable()
    {
        UpdateRecipeEvent.OnEventRaised -= UpdateRecipe;
    }

    public void UpdateRecipe()
    {
        CurrentRecipe = new List<ReagentSO>();

        while(CurrentRecipe.Count < Size)
        {
            var reagent = filteredRandom.GetNextRandom();
            if (!CurrentRecipe.Contains(reagent))
            {
                CurrentRecipe.Add(reagent);
            }
        }

        RecipeEvent.RaiseEvent(new RecipeEventData()
        {
            Reagents = new List<ReagentSO>(CurrentRecipe)
        });
    }

    public bool IsRecipeMatch(List<ReagentSO> addedReagents)
    {
        return CurrentRecipe.All(addedReagents.Contains);
    }
}
