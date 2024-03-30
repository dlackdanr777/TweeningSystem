
using UnityEngine;


namespace Muks.Tween
{
    /// <summary>
    /// Recttransform의 앵커를 기준으로 위치이동 애니메이션을 실행하는 함수
    /// </summary>
    public class TweenRectTransformAnchoredPosition : TweenData
    {
        /// <summary> 목표 회전 값 </summary>
        public Vector3 TargetAnchoredPosition;

        /// <summary> 시작 회전 값</summary>
        public Vector3 StartAnchoredPosition;

        private RectTransform _rectTransform;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if(_rectTransform == null)
            {
                if (!TryGetComponent(out _rectTransform))
                {
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
                    enabled = false;
                    return;
                }
            }

            StartAnchoredPosition = _rectTransform.anchoredPosition;
            TargetAnchoredPosition = (Vector2)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            _rectTransform.anchoredPosition = Vector3.LerpUnclamped(StartAnchoredPosition, TargetAnchoredPosition, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _rectTransform.anchoredPosition = TargetAnchoredPosition;
        }
    }
}
