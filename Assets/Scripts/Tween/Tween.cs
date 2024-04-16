using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Muks.Tween
{
    public class Tween : MonoBehaviour
    {
        private static List<Sequence> _sequenceList = new List<Sequence>();


        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreateSingleton()
        {
            GameObject obj = new GameObject("TweenManager");
            obj.AddComponent<Tween>();
            DontDestroyOnLoad(obj);
        }


        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0, count = _sequenceList.Count; i < count; i++)
            {
                _sequenceList[i].Update(deltaTime);
            }
        }


        public static Sequence Sequence()
        {
            //여기서 스레드 시작
            Sequence sequence = new Sequence();
            _sequenceList.Add(sequence);

            return sequence;
        }
        
    }

}
