using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance => instance;
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button rightArrow;

    private static UIManager instance;



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
