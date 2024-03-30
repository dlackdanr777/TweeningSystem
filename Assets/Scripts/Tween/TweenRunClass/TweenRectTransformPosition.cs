
using UnityEngine;


namespace Muks.Tween
{
    /// <summary>
    /// Recttransform�� ��Ŀ�� �������� ��ġ�̵� �ִϸ��̼��� �����ϴ� �Լ�
    /// </summary>
    public class TweenRectTransformAnchoredPosition : TweenData
    {
        /// <summary> ��ǥ ȸ�� �� </summary>
        public Vector3 TargetAnchoredPosition;

        /// <summary> ���� ȸ�� ��</summary>
        public Vector3 StartAnchoredPosition;

        private RectTransform _rectTransform;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if(_rectTransform == null)
            {
                if (!TryGetComponent(out _rectTransform))
                {
                    Debug.LogError("�ʿ� ������Ʈ�� �������� �ʽ��ϴ�.");
                    enabled = false;
                    return;
                }
            }

            StartAnchoredPosition = _rectTransform.anchoredPosition;
            TargetAnchoredPosition = (Vector2)dataSequence.TargetValue;
        }


        protected override void Update()
        {
            base.Update();

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            _rectTransform.anchoredPosition = Vector3.LerpUnclamped(StartAnchoredPosition, TargetAnchoredPosition, percent);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
                _rectTransform.anchoredPosition = TargetAnchoredPosition;
        }
    }
}
