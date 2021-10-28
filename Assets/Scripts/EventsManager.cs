using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance => instance;

    private static EventsManager instance;
    [SerializeField] private Event[] events;
    [SerializeField] private float transitionDuration;



    private void Awake()
    {
        instance = this;
        foreach (var ev in events)
        {
            ev.Init();
        }
    }

    private void Update()
    {
        foreach (var ev in events)
        {
            StartCoroutine(ev.CheckEvent(transitionDuration));
        }
    }



    [System.Serializable]
    public class Event
    {
        private bool isOver;
        [SerializeField] private Condition[] conditions;
        [SerializeField] private CharacterMovement characterMovement;

        public IEnumerator CheckEvent(float transitionDuration)
        {
            if (isOver || !ConditionsAreValid())
            {
                yield return null;
            }
            else
            {
                isOver = true;
                yield return new WaitForSeconds(transitionDuration);
                characterMovement.Apply();
            }
        }

        public bool ConditionsAreValid()
        {
            foreach (var condition in conditions)
            {
                if (!condition.IsValid())
                {
                    return false;
                }
            }
            return true;
        }

        public void Init()
        {
            foreach (var condition in conditions)
            {
                condition.Init();
            }
        }
    }

    [System.Serializable]
    public class CharacterMovement
    {
        [SerializeField] private BubbleEmitter character;
        [SerializeField] private int screenIndex;

        public void Apply()
        {
            character.MoveTo(screenIndex);
        }
    }
}

[System.Serializable]
public class Reply
{
    public string Text => text;
    public CharacterName CharacterName => characterName;

    [SerializeField] [TextArea] private string text;
    [SerializeField] private CharacterName characterName;
}

// [System.Serializable]
// public abstract class AConsequence
// {
//     public abstract void Apply();
// }