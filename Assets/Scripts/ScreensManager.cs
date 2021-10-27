using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreensManager : MonoBehaviour
{
    public static ScreensManager Instance => instance;
    public RepliesHandler[] Screens => screens;
    public bool CanGoLeft => currentScreenIndex > 0;
    public bool CanGoRight => currentScreenIndex < screens.Length - 1;
    public RepliesHandler CurrentScreen => screens[currentScreenIndex];
    // public UnityEvent OnScreenChanged => onScreenChanged;

    private static ScreensManager instance;
    [SerializeField] private RepliesHandler[] screens;
    [SerializeField] private int currentScreenIndex;
    [SerializeField] private Camera mainCamera;
    // private UnityEvent onScreenChanged;



    public void GoLeft()
    {
        if (!CanGoLeft) return;

        currentScreenIndex--;
        // onScreenChanged.Invoke();
        UIManager.Instance.UpdateArrows(this);
        SetCameraPosition();
    }

    public void GoRight()
    {
        if (!CanGoRight) return;

        currentScreenIndex++;
        // onScreenChanged.Invoke();
        UIManager.Instance.UpdateArrows(this);
        SetCameraPosition();
    }



    private void Awake()
    {
        instance = this;
        // onScreenChanged = new UnityEvent();
    }

    private void Start()
    {
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        mainCamera.transform.position = new Vector3(CurrentScreen.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
    }
}
