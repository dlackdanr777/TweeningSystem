using System.Collections.Generic;
using UnityEngine;

namespace Muks.Tween
{
    public class Tween : MonoBehaviour
    {
        private static List<Sequence> _sequenceUpdateList = new List<Sequence>();



        /// <summary> Tween Sequence ����� ����ϱ� ���� Sequence Class�� ��ȯ�ϴ� �Լ� </summary>
        public static Sequence Sequence()
        {
            //Ŭ������ �����ϰ� UpdateList�� �ø���.
            Sequence sequence = new Sequence();
            _sequenceUpdateList.Add(sequence);

            return sequence;
        }



        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateSingleton()
        {
            GameObject obj = new GameObject("MuksTween");
            obj.AddComponent<Tween>();
            DontDestroyOnLoad(obj);
        }


        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0, count = _sequenceUpdateList.Count; i < count; i++)
            {
                _sequenceUpdateList[i].Update(deltaTime);

                if (_sequenceUpdateList[i].IsEnd)
                {
                    _sequenceUpdateList.RemoveAt(i--);
                    count--;
                    continue;
                }
            }
        }
    }

}
