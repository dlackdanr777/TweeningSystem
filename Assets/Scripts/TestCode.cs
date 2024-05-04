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
        TweenMode tweenMode = TweenMode.Constant; //�ִϸ��̼� Ŀ��

        gameObject.TweenMove(new Vector3(0, 1, 0), duration, tweenMode); // �̵�
        gameObject.TweenRotate(new Vector3(0, 90, 0), duration, tweenMode); // ȸ��
        gameObject.TweenScale(new Vector3(2, 2, 2), duration, tweenMode); // ũ��

        _component.TweenMove(new Vector3(0, 1, 0), duration, tweenMode); // �̵�
        _component.TweenRotate(new Vector3(0, 90, 0), duration, tweenMode); // ȸ��
        _component.TweenScale(new Vector3(2, 2, 2), duration, tweenMode); // ������

        _rectTransform.TweenAnchoredPosition(new Vector2(0, 10), duration, tweenMode); // UI ��ġ
        _rectTransform.TweenSizeDelta(new Vector2(2, 2), duration, tweenMode); // UI ũ��

        _text.TweenColor(Color.red, duration, tweenMode); // �ؽ�Ʈ ����
        _text.TweenAlpha(0, duration, tweenMode); // �ؽ�Ʈ ���İ�

        _textMeshProUGUI.TweenColor(Color.red, duration, tweenMode); // TMP ����
        _textMeshProUGUI.TweenAlpha(1, duration, tweenMode); // TMP ���İ�

        _spriteRenderer.TweenColor(Color.red, duration, tweenMode); // ��������Ʈ ������ ����
        _spriteRenderer.TweenAlpha(1, duration,tweenMode); // ��������Ʈ ������ ���İ�

        _image.TweenColor(Color.red, duration, tweenMode); // �̹��� ����
        _image.TweenAlpha(1, duration, tweenMode); // �̹��� ���İ�

        _canvasGroup.TweenAlpha(1, duration, tweenMode); // ĵ���� �׷� ���İ�
    }

}
