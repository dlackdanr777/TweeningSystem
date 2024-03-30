using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenModeMoveTest : MonoBehaviour
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
        Tween.TransformMove(_constantObj, _constantObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Constant);
        Tween.TransformMove(_quadraticObj, _quadraticObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Quadratic);
        Tween.TransformMove(_smoothstepObj, _smoothstepObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Smoothstep);
        Tween.TransformMove(_spikeObj, _spikeObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Spike);
        Tween.TransformMove(_easeOutExpoObj, _easeOutExpoObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutExpo);
        Tween.TransformMove(_easeOutElasticObj, _easeOutElasticObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutElastic);
        Tween.TransformMove(_easeOutBackObj, _easeOutBackObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutBack);
        Tween.TransformMove(_easeOutBounceObj, _easeOutBounceObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutBounce);
    }
}
