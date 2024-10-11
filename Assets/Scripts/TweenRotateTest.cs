using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenRotateTest : MonoBehaviour
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
    [SerializeField] private Vector3 _targetAngles;
    [SerializeField] private float _duration;


    private void Start()
    {
        _constantObj.TweenRotate(_targetAngles, _duration, Ease.Constant);
        _quadraticObj.TweenRotate(_targetAngles, _duration, Ease.InQuad);
        _smoothstepObj.TweenRotate(_targetAngles, _duration, Ease.Smoothstep);
        _spikeObj.TweenRotate(_targetAngles, _duration, Ease.Spike);
        _easeOutExpoObj.TweenRotate(_targetAngles, _duration, Ease.OutExpo);
        _easeOutElasticObj.TweenRotate(_targetAngles, _duration, Ease.OutElastic);
        _easeOutBackObj.TweenRotate(_targetAngles, _duration, Ease.OutBack);
        _easeOutBounceObj.TweenRotate(_targetAngles, _duration, Ease.OutBounce);
    }
}
