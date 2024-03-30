using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenSpriteRendererAlpha : TweenData
    {
        /// <summary> 목표 위치 </summary>
        public Color TargetColor;

        /// <summary> 시작 위치</summary>
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
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
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

