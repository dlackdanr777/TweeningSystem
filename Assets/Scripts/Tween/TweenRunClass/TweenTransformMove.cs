using UnityEngine;

namespace Muks.Tween
{
    public class TweenTransformMove : TweenData
    {
        private Vector3 _startPosition;
        private Vector3 _targetPosition;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            _startPosition = transform.position;
            _targetPosition = (Vector3)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            transform.position = Vector3.LerpUnclamped(_startPosition, _targetPosition, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                transform.position = _targetPosition;
        }
    }
}
