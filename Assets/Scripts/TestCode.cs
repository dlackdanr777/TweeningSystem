using UnityEngine;
using UnityEngine.UI;
using Muks.Tween;
using TMPro;

public class TestCode : MonoBehaviour
{
    [SerializeField] private Component _component;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Text _text;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Image _image;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private CanvasGroup _canvasGroup;
    

    void Start()
    {
        float duration = 2;
        TweenMode tweenMode = TweenMode.Constant; //애니메이션 커브

        gameObject.TweenMove(new Vector3(0, 1, 0), duration, tweenMode); // 이동
        gameObject.TweenRotate(new Vector3(0, 90, 0), duration, tweenMode); // 회전
        gameObject.TweenScale(new Vector3(2, 2, 2), duration, tweenMode); // 크기

        _component.TweenMove(new Vector3(0, 1, 0), duration, tweenMode); // 이동
        _component.TweenRotate(new Vector3(0, 90, 0), duration, tweenMode); // 회전
        _component.TweenScale(new Vector3(2, 2, 2), duration, tweenMode); // 스케일

        _rectTransform.TweenAnchoredPosition(new Vector2(0, 10), duration, tweenMode); // UI 위치
        _rectTransform.TweenSizeDelta(new Vector2(2, 2), duration, tweenMode); // UI 크기

        _text.TweenColor(Color.red, duration, tweenMode); // 텍스트 색상
        _text.TweenAlpha(0, duration, tweenMode); // 텍스트 알파값

        _textMeshProUGUI.TweenColor(Color.red, duration, tweenMode); // TMP 색상
        _textMeshProUGUI.TweenAlpha(1, duration, tweenMode); // TMP 알파값

        _spriteRenderer.TweenColor(Color.red, duration, tweenMode); // 스프라이트 랜더러 색상
        _spriteRenderer.TweenAlpha(1, duration,tweenMode); // 스프라이트 랜더러 알파값

        _image.TweenColor(Color.red, duration, tweenMode); // 이미지 색상
        _image.TweenAlpha(1, duration, tweenMode); // 이미지 알파값

        _canvasGroup.TweenAlpha(1, duration, tweenMode); // 캔버스 그룹 알파값
    }

}
