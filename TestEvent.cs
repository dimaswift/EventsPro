using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventsPro;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EventsPro/Test Event")]
public class TestEvent : GenericEvent2<string, int, UnityStringEvent, TestEventListener, TestEvent>
{
    
}

[System.Serializable]
public class UnityStringEvent : UnityEvent<string, int>
{

}