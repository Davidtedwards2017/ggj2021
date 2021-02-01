using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scry/Events/Recipe Event")]
public class RecipeEventSO : ScriptableObject
{
    public RecipeEvent OnRaiseEvent = new RecipeEvent();
    public void RaiseEvent(RecipeEventData args)
    {
        if (OnRaiseEvent != null)
        {
            OnRaiseEvent.Invoke(args);
        }
    }
}

public class RecipeEventData
{
    public List<ReagentSO> Reagents;
}

public class RecipeEvent : UnityEvent<RecipeEventData> { }