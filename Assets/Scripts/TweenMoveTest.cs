using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

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

        TweenData tween = _constantObj.TweenMove(_constantObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.Constant);


        _quadraticObj.TweenMove(_quadraticObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.InQuad);
        _smoothstepObj.TweenMove(_smoothstepObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.Smoothstep);
        _spikeObj.TweenMove(_spikeObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.Spike);
        _easeOutExpoObj.TweenMove(_easeOutExpoObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.OutExpo);
        _easeOutElasticObj.TweenMove(_easeOutElasticObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.OutElastic);
        _easeOutBackObj.TweenMove(_easeOutBackObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.OutBack);
        _easeOutBounceObj.TweenMove(_easeOutBounceObj.transform.position + new Vector3(10, 0, 0), _duration, Ease.OutBounce);
    }
}
