
using UnityEngine;

namespace Muks.Tween
{
    public struct DataSequence
    {
        public int Id;
        public object StartValue;
        public object TargetValue;
        public float Duration;
        public TweenMode TweenMode;
        public Component Component;
    }
}
