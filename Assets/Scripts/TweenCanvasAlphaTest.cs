using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenCanvasAlphaTest : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;


    private void Start()
    {
        _canvasGroup.TweenAlpha(0, 3, Ease.Constant);
    }

}
