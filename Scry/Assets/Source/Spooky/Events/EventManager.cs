using System.Collections.Generic;
using System;
using Utilites;

namespace Spooky.Utilities.Events
{
    public class EventManager : Singleton<EventManager>
    {
        private Dictionary<string, Action<Dictionary<string, object>>> eventDictionary = 
            new Dictionary<string, Action<Dictionary<string, object>>>();

        public void TriggerEvent(string eventName)
        {
            TriggerEvent(eventName, null);
        }

        public void TriggerEvent(string eventName, Dictionary<string, object> message)
        {
            Action<Dictionary<string, object>> thisEvent = null;
            if (eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent.Invoke(message);
            }
        }

        public void StartListening(string eventName, Action<Dictionary<string,object>> listener)
        {
            eventDictionary.TryGetValue(eventName, out Action<Dictionary<string, object>> thisEvent);
            thisEvent += listener;
            eventDictionary.AddOrUpdate(eventName, thisEvent);
        }

        public void StopListening(string eventName, Action<Dictionary<string, object>> listener)
        {
            Action<Dictionary<string, object>> thisEvent;
            if(eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                thisEvent -= listener;
                eventDictionary[eventName] = thisEvent;
            }
        }

        public void Clear()
        {
            eventDictionary.Clear();
        }
    }
}