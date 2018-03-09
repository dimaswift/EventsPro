using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventsPro;

public class TestEventListener : GenericEventListener2<string, int, UnityStringEvent, TestEventListener, TestEvent>
{
    public override void OnEventInvoked(string args1, int args2)
    {
        Debug.Log(string.Format("{0} {1}", args1, args2)); 
    }
}
