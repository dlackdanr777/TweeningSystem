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
        _constantObj.TweenAnchoredPosition(_constantObj.anchoredPosition + _targetPos, _duration, TweenMode.Constant);
        _quadraticObj.TweenAnchoredPosition(_quadraticObj.anchoredPosition + _targetPos, _duration, TweenMode.Quadratic);
        _smoothstepObj.TweenAnchoredPosition(_smoothstepObj.anchoredPosition + _targetPos, _duration, TweenMode.Smoothstep);
        _spikeObj.TweenAnchoredPosition(_spikeObj.anchoredPosition + _targetPos, _duration, TweenMode.Spike);
        _easeOutExpoObj.TweenAnchoredPosition(_easeOutExpoObj.anchoredPosition + _targetPos, _duration, TweenMode.EaseOutExpo);
        _easeOutElasticObj.TweenAnchoredPosition(_easeOutElasticObj.anchoredPosition + _targetPos, _duration, TweenMode.EaseOutElastic);
        _easeOutBackObj.TweenAnchoredPosition(_easeOutBackObj.anchoredPosition + _targetPos, _duration, TweenMode.EaseOutBack);
        _easeOutBounceObj.TweenAnchoredPosition(_easeOutBounceObj.anchoredPosition + _targetPos, _duration, TweenMode.EaseOutBounce);
    }
}
