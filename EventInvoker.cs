using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EventsPro
{
    public class EventInvoker : MonoBehaviour
    {
        public EventInvokeMethod method;

        [SerializeField] Event _event;

        private void OnEnable()
        {
            if (method == EventInvokeMethod.OnEnable)
                _event.Invoke();
        }

        private void OnDisable()
        {
            if (method == EventInvokeMethod.OnDisable)
                _event.Invoke();
        }

        private void OnDestroy()
        {
            if (method == EventInvokeMethod.OnDestroy)
                _event.Invoke();
        }

        private void Start()
        {
            if (method == EventInvokeMethod.Start)
                _event.Invoke();
        }

        private void Awake()
        {
            if (method == EventInvokeMethod.Awake)
                _event.Invoke();
        }

        private void OnApplicationQuit()
        {
            if (method == EventInvokeMethod.OnApplicationQuit)
                _event.Invoke();
        }
    }
    
    public enum EventInvokeMethod
    {
        Awake, Start, OnEnable, OnDisable, OnDestroy, OnApplicationQuit

    }
}
