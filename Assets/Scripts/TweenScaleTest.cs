using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScaleTest : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject _constantObj;
    [SerializeField] private GameObject _quadraticObj;
    [SerializeField] private GameObject _smoothstepObj;
    [SerializeField] private GameObject _spikeObj;
    [SerializeField] private GameObject _easeOutExpoObj;
    [SerializeField] private GameObject _easeOutElasticObj;
    [SerializeField] private GameObject _easeOutBackObj;
    [SerializeField] private GameObject _easeOutBounceObj;

    [Space]
    [Header("Options")]
    [SerializeField] private float _duration;


    private void Start()
    {
        _constantObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Constant);
        _quadraticObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Quadratic);
        _smoothstepObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Smoothstep);
        _spikeObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Spike);
        _easeOutExpoObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutExpo);
        _easeOutElasticObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutElastic);
        _easeOutBackObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutBack);
        _easeOutBounceObj.TweenScale(new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutBounce);
    }
}
