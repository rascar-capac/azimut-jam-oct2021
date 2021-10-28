using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepliesHandler : MonoBehaviour
{
    [SerializeField] private Bubble bubblePrefab;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float interval;
    private Queue<ConversationBubbles> conversations;
    private float timer;



    public void CreateConversation(Conversation conversation)
    {
        Queue<Bubble> bubbles = new Queue<Bubble>();
        foreach (var reply in conversation.Replies)
        {
            Bubble bubble = Instantiate(bubblePrefab, canvas.transform);
            bubble.Init(reply, this);
            bubbles.Enqueue(bubble);
        }
        ConversationBubbles conversationBubbles = new ConversationBubbles(conversation, bubbles);
        conversations.Enqueue(conversationBubbles);
    }



    private void Awake()
    {
        conversations = new Queue<ConversationBubbles>();
        timer = interval;
    }

    private void Update()
    {
        if (conversations.Count == 0) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ConversationBubbles currentConversation = conversations.Peek();
            if (currentConversation.Bubbles.Count == 0)
            {
                conversations.Dequeue();
            }
            else
            {
                currentConversation.Bubbles.Dequeue().Show();
                timer = interval;
                if (currentConversation.Bubbles.Count == 0)
                {
                    conversations.Dequeue().Conversation.IsEnded = true;
                }
            }
        }
    }

    public class ConversationBubbles
    {
        public Conversation Conversation => conversation;
        public Queue<Bubble> Bubbles => bubbles;

        private Conversation conversation;
        private Queue<Bubble> bubbles;

        public ConversationBubbles(Conversation conversation, Queue<Bubble> bubbles)
        {
            this.conversation = conversation;
            this.bubbles = bubbles;
        }
    }
}
