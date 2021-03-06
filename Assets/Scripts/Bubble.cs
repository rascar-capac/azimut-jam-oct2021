using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Bubble : MonoBehaviour
{
    public Reply Reply => reply;

    [SerializeField] private TextMeshProUGUI context;
    [SerializeField] private float displayDuration;
    private CanvasGroup canvasGroup;
    private Transform anchor;
    private RectTransform rectTransform;
    private Reply reply;
    private RepliesHandler screen;



    public void Init(Reply reply, RepliesHandler screen)
    {
        this.reply = reply;
        context.text = reply.Text;
        this.screen = screen;
        rectTransform.position = CharactersManager.Instance.GetCharacter(reply.CharacterName).BubbleAnchor.position;
        canvasGroup.alpha = 0f;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        canvasGroup
                .DOFade(1f, 0.5f)
                .SetEase(Ease.InQuint)
                .OnComplete(() => StartCoroutine(ChronoKill()));
    }



    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    // private void Update()
    // {
    //     if (!anchor) return;

    //     rectTransform.position = anchor.position;
    // }

    private IEnumerator ChronoKill()
    {
        yield return new WaitForSeconds(displayDuration);
        Kill();
    }

    private void Kill()
    {
        canvasGroup
                .DOFade(0f, 0.5f)
                .SetEase(Ease.InQuint)
                .OnComplete(() => Destroy(gameObject));
    }
}
