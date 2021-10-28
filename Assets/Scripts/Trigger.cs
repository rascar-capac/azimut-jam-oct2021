using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Trigger : MonoBehaviour
{
    [SerializeField] private List<Sprite> alternativeSprites;
    private int currentSpriteIndex;
    private SpriteRenderer image;
    [SerializeField] private UnityEvent onClick;



    public void ChangeSprite(bool mustLoop)
    {
        if (++currentSpriteIndex >= alternativeSprites.Count)
        {
            currentSpriteIndex = mustLoop ? 0 : currentSpriteIndex - 1;
        }
        image.sprite = alternativeSprites[currentSpriteIndex];
    }

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
        alternativeSprites.Insert(0, image.sprite);
    }

    private void OnMouseDown()
    {
        onClick.Invoke();
    }
}
