using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScrollingEnd : MonoBehaviour
{
    private RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(Scroll());
    }

    private IEnumerator Scroll()
    {
        yield return new WaitForSeconds(1f);
        float height = rectTransform.rect.height;
        rectTransform.DOLocalMoveY(height + 100f, 15f).SetEase(Ease.OutCirc);
    }
}
