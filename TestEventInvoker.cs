using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventInvoker : MonoBehaviour
{
    public string message = "Test Event Invoked!";
    public int parameter = 5;

    public TestEvent _event;

    private void Awake()
    {
        _event.Invoke(message, parameter);
    }
}
