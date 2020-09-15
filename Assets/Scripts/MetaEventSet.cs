using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MetaEvent
{
    public string Name;
    public int ID;
    public UnityEvent Event;
}

[System.Serializable]
public class MetaEventSet : MonoBehaviour
{
    public List<MetaEvent> metaEvents;
}