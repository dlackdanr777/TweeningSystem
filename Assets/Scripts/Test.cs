using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Muks.Tween;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
{
    [SerializeField] private Image _image;

    void Start()
    {
        Color startColor = _image.color;
        Color targetColor = Color.white;
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, targetColor, 0.1f, TweenMode.Constant);
        Tween.IamgeColor(_image, startColor, 0.1f, TweenMode.Constant);
    }


    private void OnCompleted1()
    {
        Debug.Log("1 끝남");
    }

    private void OnCompleted2()
    {
        Debug.Log("2 끝남");
    }


    private void OnUpdated1()
    {
        Debug.Log("1 실행중");
    }

    private void OnUpdated2()
    {
        Debug.Log("2 실행중");
    }

}
