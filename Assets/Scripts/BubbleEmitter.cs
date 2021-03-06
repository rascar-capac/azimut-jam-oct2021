using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEmitter : MonoBehaviour
{
    public CharacterName Name => characterName;
    public Transform BubbleAnchor => bubbleAnchor;
    public Transform[] ScreensPositions => screensPositions;
    public int CurrentScreen => currentScreen;

    [SerializeField] private CharacterName characterName;
    [SerializeField] private Transform bubbleAnchor;
    [SerializeField] private Transform[] screensPositions;
    [SerializeField] private int currentScreen;



    public void MoveTo(int screenIndex)
    {
        transform.position = screensPositions[screenIndex].position;
        currentScreen = screenIndex;
        CharactersManager.Instance.CheckCharacterRoom(this);
    }



    private void Awake()
    {
        transform.position = screensPositions[currentScreen].position;
    }
}

public enum CharacterName
{
    CAPTAIN_MAYO,
    DOCTOR_HEARTBREAK,
    MISTER_WESLEY_GOODCAT,
    LADY_LIKEGOOD,
}
