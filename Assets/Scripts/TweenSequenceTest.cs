using Muks.Tween;
using UnityEngine;

public class TweenSequenceTest : MonoBehaviour
{
    [SerializeField] private GameObject _moveObj;
    [SerializeField] private GameObject _ratateObj;


    private void Start()
    {
        Sequence sequence = Tween.Sequence();
        TweenData data1 = _moveObj.TweenMove(_moveObj.transform.position + new Vector3(0, 3, 0),  3);
        data1.OnComplete(() => Debug.Log("data1 部!"));
        TweenData data2 = _ratateObj.TweenRotate(new Vector3(0, 360, 0), 7);
        data2.OnComplete(() => Debug.Log("data2 部!"));

        TweenData data3 = _moveObj.TweenMove(_moveObj.transform.position + new Vector3(0, -3, 0), 3);
        TweenData data4 = _ratateObj.TweenRotate(new Vector3(0, -360, 0), 7);

        sequence.AppendInterval(3);
        sequence.Append(data1);
        sequence.Join(data2);
        sequence.AppendCallback(() => Debug.Log("衛蘚蝶 1 部!"));
        sequence.AppendInterval(1);
        sequence.Append(data3);
        sequence.Join(data4);
        sequence.AppendCallback(() => Debug.Log("衛蘚蝶 2 部!"));
        sequence.Play();
        
    }
}
