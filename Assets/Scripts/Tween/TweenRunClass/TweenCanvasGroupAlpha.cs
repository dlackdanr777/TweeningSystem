using UnityEngine;

namespace Muks.Tween
{
    public class TweenCanvasGroupAlpha : TweenData
    {
        private float _startAlpha;
        private float _targetAlpha;
        private CanvasGroup _canvasGroup;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_canvasGroup == null)
            {
                if (!TryGetComponent(out _canvasGroup))
                {
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
                    enabled = false;
                    return;
                }
            }

            _targetAlpha = (float)dataSequence.TargetValue;
            _startAlpha = _canvasGroup.alpha;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);
            
            _canvasGroup.alpha = Mathf.LerpUnclamped(_startAlpha, _targetAlpha, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _canvasGroup.alpha = _targetAlpha;
        }
    }
}

