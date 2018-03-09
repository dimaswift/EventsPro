using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventsPro
{
    public class EventListener : MonoBehaviour, IEventListener
    {
        [SerializeField]
        Event _gameEvent;

        [SerializeField] UnityEvent _onEventInvoked;

        public UnityEvent onEventInvoked { get { return _onEventInvoked; } }

        [System.NonSerialized]
        bool _subscribed;


        public void SubscribeToEvent()
        {
            if (_subscribed)
                return;
            _subscribed = true;
            _gameEvent.AddListener(this);
        }

        public void UnSubscribeFromEvent()
        {
            if (!_subscribed)
                return;
            _subscribed = false;
            _gameEvent.RemoveListener(this);
        }

        private void Awake()
        {
            SubscribeToEvent();
        }

        public virtual void OnEventInvoked()
        {

        }
    }
}

public interface IEventListener
{
    void SubscribeToEvent();
    void UnSubscribeFromEvent();
}