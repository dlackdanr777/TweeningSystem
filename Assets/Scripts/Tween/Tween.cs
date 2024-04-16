using System.Collections.Generic;
using System.Threading;
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
            GameObject obj = new GameObject("MuksTween");
            obj.AddComponent<Tween>();
            DontDestroyOnLoad(obj);
        }


        private void Update()
        {
            float deltaTime = Time.deltaTime;
            for (int i = 0, count = _sequenceList.Count; i < count; i++)
            {
                if (_sequenceList[i].IsEnd)
                {
                    _sequenceList.RemoveAt(i--);
                    continue;
                }    

                _sequenceList[i].Update(deltaTime);
            }
        }



        public static Sequence Sequence()
        {
            Sequence sequence = new Sequence();
            _sequenceList.Add(sequence);

            return sequence;
        }
        
    }

}
