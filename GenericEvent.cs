using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace EventsPro
{
    public abstract class GenericEvent<TArgs, TUnityEvent, TListener, TEvent> : ScriptableObject
        where TListener : GenericEventListener<TArgs, TUnityEvent, TListener, TEvent> 
        where TEvent : GenericEvent<TArgs, TUnityEvent, TListener, TEvent>
        where TUnityEvent : UnityEvent<TArgs>
    {
        List<TListener> _listeners = new List<TListener>();

        public void AddListener(TListener listener)
        {
            if (!_listeners.Contains(listener))
            {
                _listeners.Add(listener);
            }
        }

        public void RemoveAllListeners()
        {
            _listeners.Clear();
        }

        public void RemoveListener(TListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Invoke(TArgs args)
        {
            for (int i = 0; i < _listeners.Count; i++)
            {
                _listeners[i].onEventInvoked.Invoke(args);
                _listeners[i].OnEventInvoked(args);
            }
        }
    }
}
