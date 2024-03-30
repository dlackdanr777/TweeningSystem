using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenActionTest : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    void Start()
    {
        TweenData tween = Tween.TransformMove(_target, _target.transform.position + new Vector3(6, 0, 0), 3, TweenMode.Constant).OnComplete(OnCompleted);
        tween.OnStart(OnStarted);
        tween.OnUpdate(OnUpdated);
    }

    private void OnStarted()
    {
        Debug.Log("시작");
    }

    private void OnUpdated()
    {
        Debug.Log("진행중");
    }

    private void OnCompleted()
    {
        Debug.Log("종료");
    }
}
