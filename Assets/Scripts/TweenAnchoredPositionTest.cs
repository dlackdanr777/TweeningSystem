using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenAnchoredPositionTest : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private RectTransform _constantObj;
    [SerializeField] private RectTransform _quadraticObj;
    [SerializeField] private RectTransform _smoothstepObj;
    [SerializeField] private RectTransform _spikeObj;
    [SerializeField] private RectTransform _easeOutExpoObj;
    [SerializeField] private RectTransform _easeOutElasticObj;
    [SerializeField] private RectTransform _easeOutBackObj;
    [SerializeField] private RectTransform _easeOutBounceObj;

    [Space]
    [Header("Options")]
    [SerializeField] private Vector2 _targetPos;
    [SerializeField] private float _duration;


    private void Start()
    {
        _constantObj.TweenAnchoredPosition(_constantObj.anchoredPosition + _targetPos, _duration, Ease.Constant);
        _quadraticObj.TweenAnchoredPosition(_quadraticObj.anchoredPosition + _targetPos, _duration, Ease.InQuad);
        _smoothstepObj.TweenAnchoredPosition(_smoothstepObj.anchoredPosition + _targetPos, _duration, Ease.Smoothstep);
        _spikeObj.TweenAnchoredPosition(_spikeObj.anchoredPosition + _targetPos, _duration, Ease.Spike);
        _easeOutExpoObj.TweenAnchoredPosition(_easeOutExpoObj.anchoredPosition + _targetPos, _duration, Ease.OutExpo);
        _easeOutElasticObj.TweenAnchoredPosition(_easeOutElasticObj.anchoredPosition + _targetPos, _duration, Ease.OutElastic);
        _easeOutBackObj.TweenAnchoredPosition(_easeOutBackObj.anchoredPosition + _targetPos, _duration, Ease.OutBack);
        _easeOutBounceObj.TweenAnchoredPosition(_easeOutBounceObj.anchoredPosition + _targetPos, _duration, Ease.OutBounce);
    }
}
