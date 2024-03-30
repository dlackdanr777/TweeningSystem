using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenTMPAlpha : TweenData
    {
        /// <summary> 목표 위치 </summary>
        public Color TargetColor;

        /// <summary> 시작 위치</summary>
        public Color StartColor;

        public float TargetAlpha;

        private TextMeshProUGUI _text;

        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_text == null)
            {
                if (!TryGetComponent(out _text))
                {
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
                    enabled = false;
                    return;
                }
            }

            TargetAlpha = (float)dataSequence.TargetValue;
            StartColor = _text.color;
            TargetColor = _text.color;
            TargetColor.a = TargetAlpha;
        }

        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);
            
            _text.color = Color.LerpUnclamped(StartColor, TargetColor, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _text.color = TargetColor;
        }
    }
}

