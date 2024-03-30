using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenImageAlpha : TweenData
    {
        /// <summary> ��ǥ ��ġ </summary>
        public Color TargetColor;

        /// <summary> ���� ��ġ</summary>
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
                    Debug.LogError("�ʿ� ������Ʈ�� �������� �ʽ��ϴ�.");
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

