using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizedeltaTest : MonoBehaviour
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
    [SerializeField] private Vector2 _targetSize;
    [SerializeField] private float _duration;


    private void Start()
    {
        _constantObj.TweenSizeDelta(_targetSize, _duration, Ease.Constant);
        _quadraticObj.TweenSizeDelta(_targetSize, _duration, Ease.InQuad);
        _smoothstepObj.TweenSizeDelta(_targetSize, _duration, Ease.Smoothstep);
        _spikeObj.TweenSizeDelta(_targetSize, _duration, Ease.Spike);
        _easeOutExpoObj.TweenSizeDelta(_targetSize, _duration, Ease.OutExpo);
        _easeOutElasticObj.TweenSizeDelta(_targetSize, _duration, Ease.OutElastic);
        _easeOutBackObj.TweenSizeDelta(_targetSize, _duration, Ease.OutBack);
        _easeOutBounceObj.TweenSizeDelta(_targetSize, _duration, Ease.OutBounce);
    }
}
