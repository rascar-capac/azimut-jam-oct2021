using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntValue : ScriptableObject
{
    public int Val { get => val; set => val = value;}

    [SerializeField] private int val;
}
