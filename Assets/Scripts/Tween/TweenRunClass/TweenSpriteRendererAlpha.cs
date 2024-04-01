using UnityEngine;

namespace Muks.Tween
{
    public class TweenSpriteRendererAlpha : TweenData
    {
        private Color _startColor;
        private Color _targetColor;
        private float _targetAlpha;
        private SpriteRenderer _spriteRenderer;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_spriteRenderer == null)
                _spriteRenderer = (SpriteRenderer)dataSequence.Component;

            _targetAlpha = (float)dataSequence.TargetValue;
            _startColor = _spriteRenderer.color;
            _targetColor = _spriteRenderer.color;
            _targetColor.a = _targetAlpha;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[_tweenMode](ElapsedDuration, TotalDuration);
            
            _spriteRenderer.color = Color.LerpUnclamped(_startColor, _targetColor, percent);
        }


        protected override void TweenCompleted()
        {
            if (_tweenMode != TweenMode.Spike)
                _spriteRenderer.color = _targetColor;
        }
    }
}

