using TMPro;
using UnityEngine;

namespace Muks.Tween
{
    public class TweenTMPAlpha : TweenData
    {
        private Color _startColor;
        private Color _targetColor;
        private float _targetAlpha;
        private TextMeshProUGUI _text;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_text == null)
                _text = (TextMeshProUGUI)dataSequence.Component;

            _targetAlpha = (float)dataSequence.TargetValue;
            _startColor = _text.color;
            _targetColor = _text.color;
            _targetColor.a = _targetAlpha;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[_tweenMode](ElapsedDuration, TotalDuration);
            
            _text.color = Color.LerpUnclamped(_startColor, _targetColor, percent);
        }


        protected override void TweenCompleted()
        {
            if (_tweenMode != TweenMode.Spike)
                _text.color = _targetColor;
        }
    }
}

