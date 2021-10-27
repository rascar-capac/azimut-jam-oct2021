using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEmitter : MonoBehaviour
{
    public CharacterName Name => characterName;
    public Transform BubbleAnchor => bubbleAnchor;

    [SerializeField] private CharacterName characterName;
    [SerializeField] private Transform bubbleAnchor;
}

public enum CharacterName
{
    MARCO,
    POLO,
    PENNE,
    LOPE,
    MICHEL,
    PATRICK
}
