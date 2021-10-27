using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public static CharactersManager Instance => instance;
    public BubbleEmitter[] Characters => characters;

    private static CharactersManager instance;
    [SerializeField] private BubbleEmitter[] characters;



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



    private void Awake()
    {
        instance = this;
    }
}


