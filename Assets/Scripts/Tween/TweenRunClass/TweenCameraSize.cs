
using UnityEngine;

namespace Muks.Tween
{
    public class TweenCameraSize : TweenData
    {
        private Camera _camera;

        /// <summary> 시작 회전 값</summary>
        public float StartSize;

        /// <summary> 목표 회전 값 </summary>
        public float TargetSize;


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

            StartSize = _camera.orthographicSize;
            TargetSize = (float)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            _camera.orthographicSize = Mathf.LerpUnclamped(StartSize, TargetSize, percent);
        }

        protected override void TweenCompleted()
        {
            _camera.orthographicSize = TargetSize;
        }
    }
}
