using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenImageAlpha : TweenData
    {
        private Color _startColor;
        private Color _targetColor;
        private float _targetAlpha;
        private Image _image;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_image == null)
                _image = (Image)dataSequence.Component;

            _targetAlpha = (float)dataSequence.TargetValue;
            _startColor = _image.color;
            _targetColor = _image.color;
            _targetColor.a = _targetAlpha;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[_tweenMode](ElapsedDuration, TotalDuration);

            _image.color = Color.LerpUnclamped(_startColor, _targetColor, percent);
        }


        protected override void TweenCompleted()
        {
            if(_tweenMode != TweenMode.Spike)
                _image.color = _targetColor;
        }
    }
}

