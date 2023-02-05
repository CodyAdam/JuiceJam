using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PopMoneyUI : MonoBehaviour
{
    public TMP_Text text;
    public Vector2 targetPos;
    public RectTransform rect;
    public void Init(int value)
    {
        text.text = "+$" + value.ToString();
        Vector2 currentPos = transform.position;
        // random pos in 50 50 range
        transform.position = new Vector2(Random.Range(currentPos.x - 100, currentPos.x + 100), Random.Range(currentPos.y - 100, currentPos.y + 100));
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-10, 10));
        transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutBack).onComplete += () =>
        {
            transform.DOScale(0, 0.5f).SetEase(Ease.InBack);
            rect.DOLocalMove(targetPos, 0.5f).SetEase(Ease.InBack).onComplete += () =>
            {
                Destroy(gameObject);
            };
        };
    }
}

