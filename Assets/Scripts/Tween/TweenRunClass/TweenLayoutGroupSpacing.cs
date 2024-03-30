using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{
    public class TweenLayoutGroupSpacing : TweenData
    {
        private float _startValue;
        private float _targetValue;
        private HorizontalOrVerticalLayoutGroup _layoutGroup;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_layoutGroup == null)
            {
                if (!TryGetComponent(out _layoutGroup))
                {
                    Debug.LogError("�ʿ� ������Ʈ�� �������� �ʽ��ϴ�.");
                    enabled = false;
                    return;
                }
            }
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[_tweenMode](ElapsedDuration, TotalDuration);

            _layoutGroup.spacing = Mathf.LerpUnclamped(_startValue, _targetValue, percent);
        }


        protected override void TweenCompleted()
        {
            if (_tweenMode != TweenMode.Spike)
                _layoutGroup.spacing = _targetValue;
        }
    }
}
