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
        //��ġ
        _moveObj.TweenMove(_moveObj.transform.position + new Vector3(0, -3, 0), _duration).Loop(LoopType.Yoyo);

        //ȸ��
        _rotateObj.TweenRotate(new Vector3(360, 0, 0), _duration).Loop(LoopType.Yoyo);

        //������
        _scaleObj.TweenScale(new Vector3(3, 3, 3), _duration).Loop(LoopType.Yoyo);

        //��������Ʈ ������ �÷�
        _spriteColorObj.TweenColor( new Color(0, 0, 0, 1), _duration).Loop(LoopType.Yoyo);

        //UI ��ġ
        _uiPosObj.TweenAnchoredPosition(_uiPosObj.anchoredPosition + new Vector2(0, -150), _duration).Loop(LoopType.Yoyo);

        //UI ũ��
        _uiSizeDeltaObj.TweenSizeDelta(_uiSizeDeltaObj.sizeDelta + new Vector2(100, 100), _duration).Loop(LoopType.Yoyo);

        //�̹��� �÷�
        _imageColorObj.TweenColor(new Color(0.5f, 1, 0.5f, 0.5f), _duration).Loop(LoopType.Yoyo);

        //�ؽ�Ʈ �÷�
        _tmpColorObj.TweenAlpha(0.1f, _duration).Loop(LoopType.Yoyo);


    }
}

