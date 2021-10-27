using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance => instance;
    public bool ToiletsAreClosed { get => toiletsAreClosed; set => toiletsAreClosed = value; }

    private static EventsManager instance;
    [SerializeField] private Event[] events;
    private bool toiletsAreClosed;



    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        foreach (var ev in events)
        {
            if (ev.Time >= TimeManager.Instance.Timer)
            {
                // trigger event
            }
        }
    }

    [System.Serializable]
    public class Event
    {
        public float Time => time;

        [SerializeField] private float time;
    }
}
