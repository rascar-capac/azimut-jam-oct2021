using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public static CharactersManager Instance => instance;
    public BubbleEmitter[] Characters => characters;

    private static CharactersManager instance;
    [SerializeField] private BubbleEmitter[] characters;
    [SerializeField] private Conversation[] conversations;



    public BubbleEmitter GetCharacter(CharacterName name)
    {
        foreach (var character in characters)
        {
            if (character.Name == name)
            {
                return character;
            }
        }
        return null;
    }

    public void CheckCharacterRoom(BubbleEmitter character)
    {
        foreach (var other in characters)
        {
            if (other.CurrentScreen == character.CurrentScreen)
            {
                foreach (var conversation in conversations)
                {
                    if (conversation.IsEnded) continue;

                    bool everyoneIsPresent = true;
                    foreach (var participantName in conversation.Participants)
                    {
                        BubbleEmitter participant = GetCharacter(participantName);
                        if (participant != other && participant != character)
                        {
                            everyoneIsPresent = false;
                            break;
                        }
                    }
                    if (everyoneIsPresent)
                    {
                        conversation.Start();
                    }
                    return;
                }
            }
        }
    }



    private void Awake()
    {
        instance = this;
        foreach (var conversation in conversations)
        {
            conversation.Init();
        }
    }

    private void Start()
    {
        foreach (var character in characters)
        {
            CheckCharacterRoom(character);
        }
    }
}


