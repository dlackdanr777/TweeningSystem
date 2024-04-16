using System.Collections.Generic;

namespace Muks.Tween
{
    public class Sequence
    {
        private LinkedList<SequenceData> _sequenceDataList = new LinkedList<SequenceData>();
        private float _elapsedTime;


        public void Play()
        {

        }


        internal void Update(float _deltaTime)
        {
            _elapsedTime += _deltaTime;
        }


        public Sequence Append(TweenData tweenData)
        {
            tweenData.enabled = false;
            SequenceData data = new SequenceData();

            data.TweenData = tweenData;

            _sequenceDataList.AddLast(data);
            return this;
        }

    }
}

