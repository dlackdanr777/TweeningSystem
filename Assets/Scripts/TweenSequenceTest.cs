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
        data1.OnComplete(() => Debug.Log("data1 End!"));
        TweenData data2 = _ratateObj.TweenRotate(new Vector3(0, 360, 0), 7);
        data2.OnComplete(() => Debug.Log("data2 End!"));

        TweenData data3 = _moveObj.TweenMove(_moveObj.transform.position + new Vector3(0, -3, 0), 3);
        TweenData data4 = _ratateObj.TweenRotate(new Vector3(0, -360, 0), 7);
        TweenData data5 = _moveObj.TweenMove(_moveObj.transform.position + new Vector3(0, 3, 0), 3);

        sequence.AppendInterval(1);
        sequence.Append(data1);
        sequence.Join(data2);
        sequence.AppendCallback(() => Debug.Log("Sequence1 Callback!"));
        sequence.AppendInterval(2);
        sequence.Append(data3);
        sequence.Join(data4);
        sequence.AppendCallback(() => Debug.Log("Sequence2 Callback!"));
        sequence.Append(data5);

        sequence.Play();


/*        Vector3 targetPos = new Vector3(0, 1, 0);
        Vector3 targetScale = new Vector3(2, 2, 2);
        float duration = 2;
        TweenMode tweenMode = TweenMode.Constant;

        TweenData tween1 = transform.TweenMove(targetPos, duration, tweenMode);
        TweenData tween2 = transform.TweenScale(targetScale, duration, tweenMode);

        Sequence sequence = Tween.Sequence(); //시퀀스 기능 사용

        sequence.Append(tween1); //시퀀스 마지막 Tween 추가
        sequence.Join(tween2); //시퀀스 마지막 Tween에 결합하여 동시 실행
        sequence.AppendInterval(duration); //시퀀스 마지막 일정 시간 대기 추가
        sequence.AppendCallback(() => Debug.Log("Callback")); //시퀀스 마지막 콜백 추가
        sequence.Play(); //시퀀스 시작
*/
    }
}
