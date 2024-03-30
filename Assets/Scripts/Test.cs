using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Muks.Tween;
using UnityEngine.UI;
using TMPro;

public class Test : MonoBehaviour
{

    void Start()
    {
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 5, 0), 0.1f, TweenMode.Constant);
        Tween.TransformMove(gameObject, new Vector3(0, 0, 0), 0.1f, TweenMode.Constant);
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
