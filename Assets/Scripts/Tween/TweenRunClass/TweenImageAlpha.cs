using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenImageAlpha : TweenData
    {
        /// <summary> 목표 위치 </summary>
        public Color TargetColor;

        /// <summary> 시작 위치</summary>
        public Color StartColor;

        public float TargetAlpha;

        private Image _image;

        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if(_image == null)
            {
                if (!TryGetComponent(out _image))
                {
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
                    enabled = false;
                    return;
                }
            }

            TargetAlpha = (float)dataSequence.TargetValue;
            StartColor = _image.color;
            TargetColor = _image.color;
            TargetColor.a = TargetAlpha;
        }

        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            _image.color = Color.LerpUnclamped(StartColor, TargetColor, percent);
        }

        protected override void TweenCompleted()
        {
            if(TweenMode != TweenMode.Spike)
                _image.color = TargetColor;
        }
    }
}

