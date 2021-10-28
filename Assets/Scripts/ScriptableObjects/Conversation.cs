using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Conversation : ScriptableObject
{
    public Reply[] Replies => replies;
    public bool IsEnded { get => isEnded; set => isEnded = value; }
    public CharacterName[] Participants => participants;

    [SerializeField] private Reply[] replies;
    [SerializeField] private CharacterName[] participants;
    private bool isEnded;

    public void Init()
    {
        isEnded = false;
    }
    public void Start()
    {
        int characterScreenIndex = CharactersManager.Instance.GetCharacter(replies[0].CharacterName).CurrentScreen;
        ScreensManager.Instance.Screens[characterScreenIndex].CreateConversation(this);
    }
}
