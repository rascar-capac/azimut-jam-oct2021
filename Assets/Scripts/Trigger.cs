using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Trigger : MonoBehaviour
{
    [SerializeField] private List<Sprite> alternativeSprites;
    [SerializeField] private bool mustLoop;
    private bool isOver;
    private int currentSpriteIndex;
    private SpriteRenderer image;
    [SerializeField] private UnityEvent onClick;
    [SerializeField] private GameObject outline;



    public void ChangeSprite()
    {
        if (isOver) return;

        currentSpriteIndex++;

        if (mustLoop && currentSpriteIndex >= alternativeSprites.Count)
        {
            currentSpriteIndex = 0;
        }

        if (!mustLoop && currentSpriteIndex + 1 == alternativeSprites.Count)
        {
            isOver = true;
            outline.SetActive(false);
        }

        image.sprite = alternativeSprites[currentSpriteIndex];
    }

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
        alternativeSprites.Insert(0, image.sprite);
        outline.SetActive(false);
    }

    private void OnMouseDown()
    {
        onClick.Invoke();
    }

    private void OnMouseOver()
    {
        if (isOver) return;

        outline.SetActive(true);
    }

    private void OnMouseExit()
    {
        outline.SetActive(false);
    }
}
