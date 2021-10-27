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
    CAPTAIN_MAYO,
    DOCTOR_HEARTBREAK,
    MISTER_WESLEY_GOODCAT,
    LADY_LIKEGOOD,
}
