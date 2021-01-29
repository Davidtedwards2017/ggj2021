using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utilites
{

    [System.Serializable]
    public class FilteredRandom<T>
    {
        public bool DebugMessaging = false;
        public T[] _History;
        
        public bool AllowInvalidAfterExaustedAttempts = true;
        public int MaxAttempts = 10;
        public bool PreventRepeats = true;
        public bool PreventPattern = true;

        public List<T> _Collection;

        public FilteredRandom(IEnumerable<T> collection, int historyLength)
        {
            _Collection = collection.ToList();
            _History = new T[historyLength];
        }

        public virtual T GetNextRandom()
        {
            T selected;
            var attempts = MaxAttempts;
            do
            {
                selected = _Collection.PickRandom();
                if(DebugMessaging)
                {
                    Debug.Log("picking " + selected.ToString());
                }

                if (!InvalidPick(selected))
                {
                    if(DebugMessaging)
                    {
                        Debug.Log("picked " + selected.ToString() + " attempts left " + attempts);
                    }

                    return ConfirmSelection(selected);
                }
            }
            while (attempts-- > 0 && InvalidPick(selected));

            if (AllowInvalidAfterExaustedAttempts)
            {
                if(DebugMessaging)
                {
                    Debug.Log("picked " + selected.ToString() + " attempts left " + attempts);
                }
                return ConfirmSelection(selected);
            }
            else
            {
                if(DebugMessaging)
                {
                    Debug.Log("failed to pick valid option");
                }
                return default(T);
            }
        }

        protected T ConfirmSelection(T picked)
        {
            _History = _History.Shift();
            _History[0] = picked;
            return picked;
        }

        protected virtual bool InvalidPick(T pick)
        {
            return
                WasPickedLast(pick) ||
                MatchesPattern(pick);
        }

        protected virtual bool WasPickedLast(T val)
        {
            if (!PreventRepeats || _Collection.Count == 1) return false;

            var lastPick = _History[0];
            if (lastPick == null)
            {
                return false;
            }

            return lastPick.Equals(val);
        }

        private bool MatchesPattern(T val)
        {
            if (!PreventPattern || _Collection.Count == 1) return false;

            T[] pattern = new T[2];
            pattern[0] = val;
            pattern[1] = _History[0];

            for (int i = 0; i < _History.Length - 2; i++)
            {
                if (_History[i] == null || _History[i + 1] == null) continue;
                if (_History[i].Equals(pattern[0]) && _History[i + 1].Equals(pattern[1]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}