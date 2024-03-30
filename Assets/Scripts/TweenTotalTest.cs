using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweenTotalTest : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject _moveObj;
    [SerializeField] private GameObject _rotateObj;
    [SerializeField] private GameObject _scaleObj;
    [SerializeField] private SpriteRenderer _spriteColorObj;

    [SerializeField] private RectTransform _uiPosObj;
    [SerializeField] private RectTransform _uiSizeDeltaObj;
    [SerializeField] private Image _imageColorObj;
    [SerializeField] private TextMeshProUGUI _tmpColorObj;


    [Space]
    [Header("Options")]
    [SerializeField] private float _duration;

    void Start()
    {
        Tween.TransformMove(_moveObj, _moveObj.transform.position + new Vector3(0, -3, 0), _duration).Loop(LoopType.Yoyo);
        Tween.TransformRotate(_rotateObj, new Vector3(360, 0, 0), _duration).Loop(LoopType.Yoyo);
        Tween.TransformScale(_scaleObj, new Vector3(3,3,3), _duration).Loop(LoopType.Yoyo);
        Tween.SpriteRendererColor(_spriteColorObj, new Color(0, 0, 0, 1), _duration).Loop(LoopType.Yoyo);
        Tween.RectTransfromAnchoredPosition(_uiPosObj, _uiPosObj.anchoredPosition + new Vector2(0, -150), _duration).Loop(LoopType.Yoyo);
        Tween.RectTransfromSizeDelta(_uiSizeDeltaObj, _uiSizeDeltaObj.sizeDelta + new Vector2(100, 100), _duration).Loop(LoopType.Yoyo);
        Tween.IamgeColor(_imageColorObj, new Color(0.5f, 1, 0.5f, 0.5f), _duration).Loop(LoopType.Yoyo);
        Tween.TMPColor(_tmpColorObj, new Color(1, 0.5f, 0.5f, 1), _duration).Loop(LoopType.Yoyo);
    }
}
