using System;
using System.Collections.Generic;
using UnityEngine;

namespace Muks.Tween
{
    public class Tween : MonoBehaviour
    {
        private static List<Sequence> _sequenceUpdateList = new List<Sequence>();
        private static Queue<TweenWait> _tweenWaitQueue = new Queue<TweenWait>();

        private static GameObject _waitQueueParent;

        /// <summary> Tween Sequence ����� ����ϱ� ���� Sequence Class�� ��ȯ�ϴ� �Լ� </summary>
        public static Sequence Sequence()
        {
            //Ŭ������ �����ϰ� UpdateList�� �ø���.
            Sequence sequence = new Sequence();
            _sequenceUpdateList.Add(sequence);

            return sequence;
        }

        public static TweenWait Wait(float duration, Action onCompleted)
        {
            TweenWait tween = null;
            if (_tweenWaitQueue.Count == 0)
            {
                GameObject obj = new GameObject("TweenWaitObj");
                obj.transform.parent = _waitQueueParent.transform;
                tween = obj.AddComponent<TweenWait>();
            }
            else
            {
                tween = _tweenWaitQueue.Dequeue();
            }

            //tween.Clear();
            tween.enabled = true;
            tween.AddDataSequence(new TweenDataSequence(null, duration, Ease.Constant, null));
            tween.OnComplete(() =>
            {
                onCompleted?.Invoke();
                tween.enabled = false;
                _tweenWaitQueue.Enqueue(tween);
            });

            return tween;
        }

        internal static void DequeueTweenWait(TweenWait tweenWait)
        {
            if (_tweenWaitQueue.Contains(tweenWait))
                return;

            _tweenWaitQueue.Enqueue(tweenWait);
        }



        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateObj()
        {
            GameObject obj = new GameObject("MuksTween");
            obj.AddComponent<Tween>();
            _waitQueueParent = new GameObject("WaitQueueParnet");
            _waitQueueParent.transform.parent = obj.transform;
            DontDestroyOnLoad(obj);
        }


        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0, count = _sequenceUpdateList.Count; i < count; i++)
            {
                _sequenceUpdateList[i].Update(deltaTime);

                if (!_sequenceUpdateList[i].IsEnd)
                    continue;

                    _sequenceUpdateList.RemoveAt(i--);
                    count--;
            }
        }
    }

}
