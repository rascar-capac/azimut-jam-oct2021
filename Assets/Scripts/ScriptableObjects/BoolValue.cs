using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolValue : ScriptableObject
{
    public bool Val { get => val; set => val = value; }
    public bool InitialVal => initialVal;

    [SerializeField] private bool initialVal;
    private bool val;

    public void Init()
    {
        val = initialVal;
    }

    public void Toggle()
    {
        val = !val;
    }
}
