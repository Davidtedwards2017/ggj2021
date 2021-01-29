using Spooky.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilites;

namespace Spooky.Ui
{
    public class UiStateController : Singleton<UiStateController>
    {
        private Dictionary<UiStateSO, bool> uiStates = new Dictionary<UiStateSO, bool>();
        private Dictionary<UiStateSO, List<Module>> modules = new Dictionary<UiStateSO, List<Module>>();

        public void SetAll(bool enable)
        {
            foreach (var uiState in EnumExtensions.GetValues<UiStateSO>())
            {
                SetState(uiState, enable);
            }
        }

        public void SetState(UiStateSO state, bool enabled)
        {
            if (uiStates.ContainsKey(state))
            {
                var oldValue = uiStates[state];
                if(oldValue == enabled)
                {
                    return;
                }
            }

            Debug.Log("Ui State (" + state.ToString()+ ") set to -> " + enabled);
            uiStates.SafeSet(state, enabled);
            UpdateSubscribers(state);
        }

        private void UpdateSubscribers(UiStateSO state)
        {
            bool enabled;
            if(uiStates.TryGetValue(state, out enabled))
            {
                foreach(var module in modules.SafeGetOrInitialize(state))
                {
                    module.Active = enabled;
                }
            }
        }

        public void Subscribe(Module module)
        {
            var moduleCollection = modules.SafeGetOrInitialize(module.UiState);
            moduleCollection.AddIfUnique(module);
        }

        public void Unsubscribe(Module module)
        {
            var moduleCollection = modules.SafeGetOrInitialize(module.UiState);
            moduleCollection.SafeRemove(module);
        }

        public bool GetState(UiStateSO state)
        {
            return uiStates.SafeGetOrInitialize(state);
        }

    }
}