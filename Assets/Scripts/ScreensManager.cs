using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager Instance => instance;
    public bool CanGoLeft => currentScreenIndex > 0;
    public bool CanGoRight => currentScreenIndex < screens.Length - 1;

    private static ScreensManager instance;
    [SerializeField] private GameObject[] screens;
    [SerializeField] private int currentScreenIndex;



    public void GoLeft()
    {
        if (!CanGoLeft) return;

        screens[currentScreenIndex].SetActive(false);
        currentScreenIndex--;
        screens[currentScreenIndex].SetActive(true);
        UIManager.Instance.UpdateArrows(this);
    }

    public void GoRight()
    {
        if (!CanGoRight) return;

        screens[currentScreenIndex].SetActive(false);
        currentScreenIndex++;
        screens[currentScreenIndex].SetActive(true);
        UIManager.Instance.UpdateArrows(this);
    }



    private void Awake()
    {
        instance = this;

        foreach(var screen in screens)
        {
            screen.SetActive(false);
        }

        screens[currentScreenIndex].SetActive(true);
    }



    // [System.Serializable]
    // public class Screen
    // {
    //     [SerializeField] GameObject gameObject;
    //     [SerializeField]
    // }
}
