using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => instance;
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button rightArrow;

    private static UIManager instance;



    public void UpdateTimer(float timer)
    {
        int milliseconds = (int) ((timer % 1) * 1000);
        int seconds = (int) timer % 10;
        int minutes = (int) timer / 10;
        this.timer.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void UpdateArrows(ScreensManager screensManager)
    {
        leftArrow.interactable = screensManager.CanGoLeft;
        rightArrow.interactable = screensManager.CanGoRight;
    }



    private void Awake()
    {
        instance = this;
    }
}
