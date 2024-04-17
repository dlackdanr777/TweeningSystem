using System.Collections.Generic;
using UnityEngine;

namespace Muks.Tween
{
    public class Tween : MonoBehaviour
    {
        private static List<Sequence> _sequenceUpdateList = new List<Sequence>();



        /// <summary> Tween Sequence 기능을 사용하기 위해 Sequence Class를 반환하는 함수 </summary>
        public static Sequence Sequence()
        {
            //클래스를 생성하고 UpdateList에 올린다.
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
