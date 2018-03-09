using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventsPro
{
    [CreateAssetMenu(menuName = "EventsPro/Event")]
    public class Event : ScriptableObject
    {
        List<EventListener> _listeners = new List<EventListener>();

        public void AddListener(EventListener listener)
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

        public void RemoveListener(EventListener listener)
        {
            _listeners.Remove(listener);
        }

        [ContextMenu("Invoke")]
        public void Invoke()
        {
            for (int i = 0; i < _listeners.Count; i++)
            {
                _listeners[i].onEventInvoked.Invoke();
                _listeners[i].OnEventInvoked();
            }
        }
    }
}

