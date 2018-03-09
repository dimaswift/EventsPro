using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace EventsPro
{
    public abstract class GenericEvent2<TArgs1, TArgs2, TUnityEvent, TListener, TEvent> : ScriptableObject
        where TListener : GenericEventListener2<TArgs1, TArgs2, TUnityEvent, TListener, TEvent>
        where TEvent : GenericEvent2<TArgs1, TArgs2, TUnityEvent, TListener, TEvent>
        where TUnityEvent : UnityEvent<TArgs1, TArgs2>
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
            for (int i = 0; i < _listeners.Count; i++)
            {
                _listeners[i].UnSubscribeFromEvent();
            }

            _listeners.Clear();
        }

        public void RemoveListener(TListener listener)
        {
            _listeners.Remove(listener);
        }

        public void Invoke(TArgs1 args1, TArgs2 args2)
        {
            for (int i = 0; i < _listeners.Count; i++)
            {
                _listeners[i].onEventInvoked.Invoke(args1, args2);
                _listeners[i].OnEventInvoked(args1, args2);
            }
        }
    }
}
