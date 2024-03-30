
using UnityEngine;

namespace Muks.Tween
{
    public class TweenCameraSize : TweenData
    {
        private Camera _camera;

        /// <summary> ���� ȸ�� ��</summary>
        public float StartSize;

        /// <summary> ��ǥ ȸ�� �� </summary>
        public float TargetSize;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_camera == null)
            {
                if (!TryGetComponent(out _camera))
                {
                    Debug.LogError("�ʿ� ������Ʈ�� �������� �ʽ��ϴ�.");
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
