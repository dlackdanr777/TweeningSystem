using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenMoveTest : MonoBehaviour
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
        _constantObj.TweenMove(_constantObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Constant);
        _quadraticObj.TweenMove(_quadraticObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Quadratic);
        _smoothstepObj.TweenMove(_smoothstepObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Smoothstep);
        _spikeObj.TweenMove(_spikeObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.Spike);
        _easeOutExpoObj.TweenMove(_easeOutExpoObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutExpo);
        _easeOutElasticObj.TweenMove(_easeOutElasticObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutElastic);
        _easeOutBackObj.TweenMove(_easeOutBackObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutBack);
        _easeOutBounceObj.TweenMove(_easeOutBounceObj.transform.position + new Vector3(10, 0, 0), _duration, TweenMode.EaseOutBounce);
    }
}
