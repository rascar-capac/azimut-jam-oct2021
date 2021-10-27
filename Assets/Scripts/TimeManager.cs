using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance => instance;
    public float Timer => timer;

    private static TimeManager instance;
    [SerializeField] private float endTime;
    private float timer;



    public void Reset()
    {
        timer = 0;
    }



    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        UIManager.Instance.UpdateTimer(timer);
    }
}
