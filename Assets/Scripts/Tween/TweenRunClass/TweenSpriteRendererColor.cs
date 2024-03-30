using UnityEngine;

namespace Muks.Tween
{
    public class TweenSpriteRendererColor : TweenData
    {
        private Color _startColor;
        private Color _targetColor;
        private SpriteRenderer _spriteRenderer;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_spriteRenderer == null)
            {
                if (!TryGetComponent(out _spriteRenderer))
                {
                    Debug.LogError("�ʿ� ������Ʈ�� �������� �ʽ��ϴ�.");
                    enabled = false;
                    return;
                }
            }

            _startColor = _spriteRenderer.color;
            _targetColor = (Color)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            _spriteRenderer.color = Color.LerpUnclamped(_startColor, _targetColor, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _spriteRenderer.color = _targetColor;
        }
    }
}

