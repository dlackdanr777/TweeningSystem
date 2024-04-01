using Muks.Tween;
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
        //위치
        _moveObj.TweenMove(_moveObj.transform.position + new Vector3(0, -3, 0), _duration).Loop(LoopType.Yoyo);

        //회전
        _rotateObj.TweenRotate(new Vector3(360, 0, 0), _duration).Loop(LoopType.Yoyo);

        //스케일
        _scaleObj.TweenScale(new Vector3(3, 3, 3), _duration).Loop(LoopType.Yoyo);

        //스프라이트 랜더러 컬러
        _spriteColorObj.TweenColor( new Color(0, 0, 0, 1), _duration).Loop(LoopType.Yoyo);

        //UI 위치
        _uiPosObj.TweenAnchoredPosition(_uiPosObj.anchoredPosition + new Vector2(0, -150), _duration).Loop(LoopType.Yoyo);

        //UI 크기
        _uiSizeDeltaObj.TweenSizeDelta(_uiSizeDeltaObj.sizeDelta + new Vector2(100, 100), _duration).Loop(LoopType.Yoyo);

        //이미지 컬러
        _imageColorObj.TweenColor(new Color(0.5f, 1, 0.5f, 0.5f), _duration).Loop(LoopType.Yoyo);

        //텍스트 컬러
        _tmpColorObj.TweenAlpha(0.1f, _duration).Loop(LoopType.Yoyo);


    }
}

