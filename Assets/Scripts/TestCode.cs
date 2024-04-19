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

        Sequence sequence = Tween.Sequence(); //������ ��� ���

        sequence.Append(tween); //Tween �߰�
        sequence.AppendInterval(3); //�����ð� ���
        sequence.Append(tween); //Tween �߰�
        sequence.Join(tween2); //������ Sequence Tween�� ���յǾ� ���� ���� ����
        sequence.AppendCallback(() => Debug.Log("Callback")); // �ݹ� �߰�
        sequence.Play(); //������ ����

        tween.OnStart(() => Debug.Log("����"));
        tween.OnUpdate(() => Debug.Log("������"));
        tween.OnComplete(() => Debug.Log("�Ϸ�"));

        transform.TweenStop(); //����
        transform.TweenPause(); //�Ͻ� ����
        transform.TweenRestart(); // �Ͻ� ���� ����


        

    }

}
