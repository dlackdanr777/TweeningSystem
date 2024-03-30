using UnityEngine;

namespace Muks.Tween
{
    public class TweenRectTransformSizeDelta : TweenData
    {
        private Vector2 _startSizeDelta;
        private Vector2 _targetSizeDelta;
        private RectTransform _rectTransform;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_rectTransform == null)
            {
                if (!TryGetComponent(out _rectTransform))
                {
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
                    enabled = false;
                    return;
                }
            }

            _startSizeDelta = _rectTransform.sizeDelta;
            _targetSizeDelta = (Vector2)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            float width = Mathf.LerpUnclamped(_startSizeDelta.x, _targetSizeDelta.x, percent);
            float height = Mathf.LerpUnclamped(_startSizeDelta.y, _targetSizeDelta.y, percent);
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
            {
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _targetSizeDelta.x);
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _targetSizeDelta.y);
            }  
        }
    }
}
