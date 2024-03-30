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
                    Debug.LogError("필요 컴포넌트가 존재하지 않습니다.");
                    enabled = false;
                    return;
                }
            }
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            _layoutGroup.spacing = Mathf.LerpUnclamped(_startValue, _targetValue, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _layoutGroup.spacing = _targetValue;
        }
    }
}
