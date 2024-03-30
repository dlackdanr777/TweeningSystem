using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenTMPAlpha : TweenData
    {
        /// <summary> ��ǥ ��ġ </summary>
        public Color TargetColor;

        /// <summary> ���� ��ġ</summary>
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
                    Debug.LogError("�ʿ� ������Ʈ�� �������� �ʽ��ϴ�.");
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

