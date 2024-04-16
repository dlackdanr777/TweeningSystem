using Muks.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenSequenceTest : MonoBehaviour
{
    [SerializeField] private GameObject _moveObj;


    private void Start()
    {
        Sequence sequence = Tween.Sequence();
        TweenData data1 = _moveObj.TweenMove(_moveObj.transform.position + new Vector3(0, 3, 0),  3);

        sequence.AppendInterval(1);
        sequence.Append(data1);
        sequence.AppendCallback(() => Debug.Log("³¡!"));
        sequence.Play();
        
    }
}
