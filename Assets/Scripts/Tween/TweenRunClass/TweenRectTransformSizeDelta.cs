
using UnityEngine;


namespace Muks.Tween
{
    /// <summary>
    /// Recttransform�� width�� height�� �����ϴ� Tween
    /// </summary>
    public class TweenRectTransformSizeDelta : TweenData
    {
        /// <summary> ��ǥ ȸ�� �� </summary>
        public Vector2 TargetSizeDelta;

        /// <summary> ���� ȸ�� ��</summary>
        public Vector2 StartSizeDelta;

        private RectTransform _rectTransform;


        public override void SetData(DataSequence dataSequence)
        {
            base.SetData(dataSequence);

            if (_rectTransform == null)
            {
                if (!TryGetComponent(out _rectTransform))
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

            float percent = _percentHandler[TweenMode](ElapsedDuration, TotalDuration);

            float width = Mathf.LerpUnclamped(StartSizeDelta.x, TargetSizeDelta.x, percent);
            float height = Mathf.LerpUnclamped(StartSizeDelta.y, TargetSizeDelta.y, percent);
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        }


        protected override void TweenCompleted()
        {
            if (TweenMode != TweenMode.Spike)
            {
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, TargetSizeDelta.x);
                _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, TargetSizeDelta.y);
            }  
        }
    }
}
