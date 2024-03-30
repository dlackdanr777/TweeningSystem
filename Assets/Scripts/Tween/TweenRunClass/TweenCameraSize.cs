using UnityEngine;

namespace Muks.Tween
{
    public class TweenCameraSize : TweenData
    {
        private float _startSize;
        private float _targetSize;
        private Camera _camera;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_camera == null)
            {
                if (!TryGetComponent(out _camera))
                {
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
                    enabled = false;
                    return;
                }
            }

            _startSize = _camera.orthographicSize;
            _targetSize = (float)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            _camera.orthographicSize = Mathf.LerpUnclamped(_startSize, _targetSize, percent);
        }


        protected override void TweenCompleted()
        {
            if(TweenMode != TweenMode.Spike)
                _camera.orthographicSize = _targetSize;
        }
    }
}
