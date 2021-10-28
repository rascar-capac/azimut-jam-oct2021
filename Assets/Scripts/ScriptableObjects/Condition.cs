using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Condition : ScriptableObject
{
    [SerializeField] private ConditionType conditionType;
    [Space] [Space]
    [SerializeField] private BoolValue eventCondition;
    [SerializeField] private float timeValue;
    [SerializeField] private CharacterPosition characterPosition;

    public bool IsValid()
    {
        switch (conditionType)
        {
            case ConditionType.EVENT_CONDITION:
                return eventCondition.Val;
            case ConditionType.TIME_VALUE:
                return TimeManager.Instance.Timer >= timeValue;
            case ConditionType.CHARACTER_POSITION:
                return CharactersManager.Instance.GetCharacter(characterPosition.CharacterName).CurrentScreen == characterPosition.ScreenIndex;
            default:
                return false;
        }
    }

    public void Init()
    {
        eventCondition.Init();
    }



    public enum ConditionType
    {
        EVENT_CONDITION,
        TIME_VALUE,
        CHARACTER_POSITION
    }

    [System.Serializable]
    public class CharacterPosition
    {
        public CharacterName CharacterName => characterName;
        public int ScreenIndex => screenIndex;

        [SerializeField] private CharacterName characterName;
        [SerializeField] private int screenIndex;
    }
}
