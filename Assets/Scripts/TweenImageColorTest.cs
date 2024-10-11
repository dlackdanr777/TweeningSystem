using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TweenImageColorTest : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private Image _constantObj;
    [SerializeField] private Image _quadraticObj;
    [SerializeField] private Image _smoothstepObj;
    [SerializeField] private Image _spikeObj;
    [SerializeField] private Image _easeOutExpoObj;
    [SerializeField] private Image _easeOutElasticObj;
    [SerializeField] private Image _easeOutBackObj;
    [SerializeField] private Image _easeOutBounceObj;

    [Space]
    [Header("Options")]
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;


    private void Start()
    {
        _constantObj.TweenColor(_targetColor, _duration, Ease.Constant);
        _quadraticObj.TweenColor(_targetColor, _duration, Ease.InQuad);
        _smoothstepObj.TweenColor(_targetColor, _duration, Ease.Smoothstep);
        _spikeObj.TweenColor(_targetColor, _duration, Ease.Spike);
        _easeOutExpoObj.TweenColor(_targetColor, _duration, Ease.OutExpo);
        _easeOutElasticObj.TweenColor(_targetColor, _duration, Ease.OutElastic);
        _easeOutBackObj.TweenColor(_targetColor, _duration, Ease.OutBack);
        _easeOutBounceObj.TweenColor(_targetColor, _duration, Ease.OutBounce);
    }
}
