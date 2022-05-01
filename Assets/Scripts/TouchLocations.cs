using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocations
{
    public int touchId;
    public GameObject objectRef;

    public TouchLocations(int newTouchId, GameObject newObjectRef)
    {
        touchId = newTouchId;
        objectRef = newObjectRef;
    }
}
