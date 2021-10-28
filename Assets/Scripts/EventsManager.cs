using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance => instance;

    private static EventsManager instance;
    [SerializeField] private Event[] events;



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
            ev.CheckEvent();
        }
    }



    [System.Serializable]
    public class Event
    {
        private bool isOver;
        [SerializeField] private Condition[] conditions;
        [SerializeField] private AConsequence consequence;

        public void CheckEvent()
        {
            if (!isOver && ConditionsAreValid())
            {
                consequence.Apply();
                isOver = true;
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

    // [System.Serializable]
    // public class CharacterMovement : AConsequence
    // {
    //     [SerializeField] private BubbleEmitter character;
    //     [SerializeField] private int screenIndex;

    //     public override void Apply()
    //     {
    //         character.MoveTo(screenIndex);
    //     }
    // }
}

[System.Serializable]
public class Reply
{
    public string Text => text;
    public CharacterName CharacterName => characterName;

    [SerializeField] [TextArea] private string text;
    [SerializeField] private CharacterName characterName;
}

public abstract class AConsequence : ScriptableObject
{
    public abstract void Apply();
}