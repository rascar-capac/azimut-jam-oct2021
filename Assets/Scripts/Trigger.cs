using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent onClick;



    private void Awake()
    {
        onClick = new UnityEvent();
    }

    private void onMouseDown()
    {
        onClick.Invoke();
    }
}
