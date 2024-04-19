using UnityEngine;
using UnityEngine.UI;
using Muks.Tween;
using TMPro;

public class TestCode : MonoBehaviour
{

    void Start()
    {
        Vector3 targetPos = new Vector3(0, 1, 0);
        Vector3 targetScale = new Vector3(2, 2, 2);
        float duration = 2;
        TweenMode tweenMode = TweenMode.Constant;

        TweenData tween = transform.TweenMove(targetPos, duration, TweenMode.Constant);
        TweenData tween2 = transform.TweenScale(targetScale, duration, tweenMode);

        Sequence sequence = Tween.Sequence(); //시퀀스 기능 사용

        sequence.Append(tween); //Tween 추가
        sequence.AppendInterval(3); //일정시간 대기
        sequence.Append(tween); //Tween 추가
        sequence.Join(tween2); //마지막 Sequence Tween에 결합되어 동시 실행 가능
        sequence.AppendCallback(() => Debug.Log("Callback")); // 콜백 추가
        sequence.Play(); //시퀀스 시작

        tween.OnStart(() => Debug.Log("시작"));
        tween.OnUpdate(() => Debug.Log("진행중"));
        tween.OnComplete(() => Debug.Log("완료"));

        transform.TweenStop(); //정지
        transform.TweenPause(); //일시 정지
        transform.TweenRestart(); // 일시 정지 해제


        

    }

}
