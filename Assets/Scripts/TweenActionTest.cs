using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenActionTest : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _pauseButton;



    void Start()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
        _pauseButton.onClick.AddListener(OnPauseButtonClicked);

        TweenData tween = _target.TweenMove(_target.transform.position + new Vector3(6, 0, 0), 10, TweenMode.Constant);
        tween.OnStart(OnStarted);
        tween.OnUpdate(OnUpdated);
        tween.OnComplete(OnCompleted);
    }

    private void OnStarted()
    {
        Debug.Log("����");
    }

    private void OnUpdated()
    {
        Debug.Log("������");
    }

    private void OnCompleted()
    {
        Debug.Log("����");
    }


    private void OnPauseButtonClicked()
    {
        _target.TweenPause();
    }

    private void OnRestartButtonClicked()
    {
        _target.TweenRestart();
    }
}
