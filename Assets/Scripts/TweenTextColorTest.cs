using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TweenTextColorTest : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private TextMeshProUGUI _constantObj;
    [SerializeField] private TextMeshProUGUI _quadraticObj;
    [SerializeField] private TextMeshProUGUI _smoothstepObj;
    [SerializeField] private TextMeshProUGUI _spikeObj;
    [SerializeField] private TextMeshProUGUI _easeOutExpoObj;
    [SerializeField] private TextMeshProUGUI _easeOutElasticObj;
    [SerializeField] private TextMeshProUGUI _easeOutBackObj;
    [SerializeField] private TextMeshProUGUI _easeOutBounceObj;

    [Space]
    [Header("Options")]
    [SerializeField] private Color _targetColor;
    [SerializeField] private float _duration;


    private void Start()
    {
        _constantObj.TweenColor(_targetColor, _duration, TweenMode.Constant);
        _quadraticObj.TweenColor(_targetColor, _duration, TweenMode.Quadratic);
        _smoothstepObj.TweenColor(_targetColor, _duration, TweenMode.Smoothstep);
        _spikeObj.TweenColor(_targetColor, _duration, TweenMode.Spike);
        _easeOutExpoObj.TweenColor(_targetColor, _duration, TweenMode.EaseOutExpo);
        _easeOutElasticObj.TweenColor(_targetColor, _duration, TweenMode.EaseOutElastic);
        _easeOutBackObj.TweenColor(_targetColor, _duration, TweenMode.EaseOutBack);
        _easeOutBounceObj.TweenColor(_targetColor, _duration, TweenMode.EaseOutBounce);
    }
}
