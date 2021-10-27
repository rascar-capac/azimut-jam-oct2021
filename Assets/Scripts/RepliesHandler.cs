using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepliesHandler : MonoBehaviour
{
    public Reply[] Replies => replies;

    [SerializeField] private Bubble bubblePrefab;
    [SerializeField] private Reply[] replies;
    private List<Bubble> bubbles;
    private Canvas canvas;



    public void RemoveBubble(Bubble bubble)
    {
        bubbles.Remove(bubble);
        Destroy(bubble.gameObject);
    }



    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        CreateBubbles();
        foreach (var bubble in bubbles)
        {
            bubble.gameObject.SetActive(false);
        }
        // ScreensManager.Instance.OnScreenChanged.AddListener(HideAllBubbles);
    }

    private void Update()
    {
        foreach (var bubble in bubbles)
        {
            if (!bubble.gameObject.activeSelf && bubble.Reply.Time <= TimeManager.Instance.Timer)
            {
                bubble.Show();
            }
        }
    }

    private void CreateBubbles()
    {
        bubbles = new List<Bubble>();
        foreach (var reply in Replies)
        {
            Bubble bubble = Instantiate(bubblePrefab, canvas.transform);
            bubble.Init(reply, this);
            bubbles.Add(bubble);
        }
    }
}

[System.Serializable]
public class Reply
{
    public string Text => text;
    public float Time => time;
    public CharacterName CharacterName => characterName;

    [SerializeField] [TextArea] private string text;
    [SerializeField] private float time;
    [SerializeField] private CharacterName characterName;
}
