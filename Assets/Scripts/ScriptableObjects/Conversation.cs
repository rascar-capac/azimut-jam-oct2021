using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Conversation : AConsequence
{
    public Reply[] Replies => replies;

    [SerializeField] private Reply[] replies;

    public override void Apply()
    {
        int characterScreenIndex = CharactersManager.Instance.GetCharacter(replies[0].CharacterName).CurrentScreen;
        ScreensManager.Instance.Screens[characterScreenIndex].CreateBubbles(replies);
    }
}
