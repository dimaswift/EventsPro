using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventsPro
{
    public abstract class GenericEventListener<TArgs, TUnityEvent, TListener, TEvent> : 
        MonoBehaviour 
        where TListener : GenericEventListener<TArgs, TUnityEvent, TListener, TEvent>
        where TEvent : GenericEvent<TArgs, TUnityEvent, TListener, TEvent> 
        where TUnityEvent : UnityEvent<TArgs>
    {
        [SerializeField]
        TEvent _gameEvent;

        [SerializeField] TUnityEvent _onEventInvoked;

        public TUnityEvent onEventInvoked { get { return _onEventInvoked; } }

        [System.NonSerialized]
        bool _subscribed;

        TListener _listener;

        public void SubscribeToEvent()
        {
            if (_subscribed)
                return;
            _subscribed = true;
            if (!_listener)
                _listener = GetComponent<TListener>();
            _gameEvent.AddListener(_listener);
        }

        public void UnSubscribeFromEvent()
        {
            if (!_subscribed)
                return;
            _subscribed = false;
            if (!_listener)
                _listener = GetComponent<TListener>();
            _gameEvent.RemoveListener(_listener);
        }

        private void Awake()
        {
            SubscribeToEvent();
        }

        public virtual void OnEventInvoked(TArgs args)
        {

        }
    }

}
