using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenModeScaleTest : MonoBehaviour
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
        Tween.TransformScale(_constantObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Constant);
        Tween.TransformScale(_quadraticObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Quadratic);
        Tween.TransformScale(_smoothstepObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Smoothstep);
        Tween.TransformScale(_spikeObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.Spike);
        Tween.TransformScale(_easeOutExpoObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutExpo);
        Tween.TransformScale(_easeOutElasticObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutElastic);
        Tween.TransformScale(_easeOutBackObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutBack);
        Tween.TransformScale(_easeOutBounceObj, new Vector3(1.7f, 1.7f, 1.7f), _duration, TweenMode.EaseOutBounce);
    }
}
