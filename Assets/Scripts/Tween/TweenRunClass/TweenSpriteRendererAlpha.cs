using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenSpriteRendererAlpha : TweenData
    {
        /// <summary> ��ǥ ��ġ </summary>
        public Color TargetColor;

        /// <summary> ���� ��ġ</summary>
        public Color StartColor;

        public float TargetAlpha;

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

            TargetAlpha = (float)dataSequence.TargetValue;
            StartColor = _spriteRenderer.color;
            TargetColor = _spriteRenderer.color;
            TargetColor.a = TargetAlpha;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);
            
            _spriteRenderer.color = Color.LerpUnclamped(StartColor, TargetColor, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _spriteRenderer.color = TargetColor;
        }
    }
}

