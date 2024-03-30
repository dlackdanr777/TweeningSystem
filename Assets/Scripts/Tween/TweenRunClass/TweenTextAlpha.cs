using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenTextAlpha : TweenData
    {
        private Color _startColor;
        private Color _targetColor;
        private float _targetAlpha;
        private Text _text;


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

            _targetAlpha = (float)dataSequence.TargetValue;
            _startColor = _text.color;
            _targetColor = _text.color;
            _targetColor.a = _targetAlpha;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);
            
            _text.color = Color.LerpUnclamped(_startColor, _targetColor, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _text.color = _targetColor;
        }
    }
}

