using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepliesHandler : MonoBehaviour
{
    [SerializeField] private Bubble bubblePrefab;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float interval;
    private Queue<Bubble> bubbles;
    private float timer;



    public void CreateBubbles(Reply[] replies)
    {
        foreach (var reply in replies)
        {
            Bubble bubble = Instantiate(bubblePrefab, canvas.transform);
            bubble.Init(reply, this);
            bubbles.Enqueue(bubble);
        }
    }



    private void Awake()
    {
        bubbles = new Queue<Bubble>();
        timer = interval;
    }

    private void Update()
    {
        if (bubbles.Count == 0) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            bubbles.Dequeue().Show();
            timer = interval;
        }
    }
}
