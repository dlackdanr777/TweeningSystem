using UnityEngine;

namespace Muks.Tween
{
    public class TweenRectTransformAnchoredPosition : TweenData
    {
        private Vector2 _startAnchoredPosition;
        private Vector2 _targetAnchoredPosition;
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

            _startAnchoredPosition = _rectTransform.anchoredPosition;
            _targetAnchoredPosition = (Vector2)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[_tweenMode](ElapsedDuration, TotalDuration);

            _rectTransform.anchoredPosition = Vector2.LerpUnclamped(_startAnchoredPosition, _targetAnchoredPosition, percent);
        }


        protected override void TweenCompleted()
        {
            if (_tweenMode != TweenMode.Spike)
                _rectTransform.anchoredPosition = _targetAnchoredPosition;
        }
    }
}
