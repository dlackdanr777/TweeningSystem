using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Muks.Tween
{

    public static class ExtensionMethod
    {
        /// <summary>�Ͻ������� ��� Tween Ŭ���� ����</summary>
        public static void TweenRestart(this Component target)
        {
            TweenData[] tweens = target.GetComponents<TweenData>();

            foreach (TweenData tween in tweens)
            {
                tween.enabled = true;
            }
        }

        /// <summary>�Ͻ������� ��� Tween Ŭ���� ����</summary>
        public static void TweenRestart(this GameObject target)
        {
            TweenRestart(target.transform);
        }


        /// <summary>�ش� ������Ʈ�� ��� Tween ���� �Լ�</summary>
        public static void TweenStop(this Component target)
        {
            TweenData[] tweens = target.GetComponents<TweenData>();

            foreach (TweenData tween in tweens)
            {
                tween.Clear();
            }
        }

        /// <summary>�ش� ������Ʈ�� ��� Tween ���� �Լ�</summary>
        public static void TweenStop(this GameObject target)
        {
            TweenStop(target.transform);
        }


        /// <summary>�ش� ������Ʈ�� ��� Tween �Ͻ� ���� �Լ�(Play() ȣ�� ������ ����)</summary>
        public static void TweenPause(this Component target)
        {
            TweenData[] tweens = target.GetComponents<TweenData>();

            foreach (TweenData tween in tweens)
            {
                tween.enabled = false;
            }
        }

        /// <summary>�ش� ������Ʈ�� ��� Tween �Ͻ� ���� �Լ�(Play() ȣ�� ������ ����)</summary>
        public static void TweenPause(this GameObject target)
        {
            TweenPause(target.transform);
        }


        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TweenMove(this Component target, Vector3 targetPosition, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformMove tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformMove>();

            TweenDataSequence tmpData = new TweenDataSequence(targetPosition, duration, ease, null);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TweenMove(this GameObject target, Vector3 targetPosition, float duration, Ease ease = Ease.Constant)
        {
            return TweenMove(target.transform, targetPosition, duration, ease);
        }


        /// <summary>��ǥ X������ ���� �ð����� ������Ʈ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TweenMoveX(this Component target, float targetPosX, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformMoveX tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformMoveX>();

            TweenDataSequence tmpData = new TweenDataSequence(targetPosX, duration, ease, null);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ X������ ���� �ð����� ������Ʈ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TweenMoveX(this GameObject target, float targetPosX, float duration, Ease ease = Ease.Constant)
        {
            return TweenMoveX(target.transform, targetPosX, duration, ease);
        }


        /// <summary>��ǥ Y������ ���� �ð����� ������Ʈ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TweenMoveY(this Component target, float targetPosY, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformMoveY tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformMoveY>();

            TweenDataSequence tmpData = new TweenDataSequence(targetPosY, duration, ease, null);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ Y������ ���� �ð����� ������Ʈ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TweenMoveY(this GameObject target, float targetPosY, float duration, Ease ease = Ease.Constant)
        {
            return TweenMoveY(target.transform, targetPosY, duration, ease);
        }


        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� ȸ����Ű�� �Լ�</summary>
        public static TweenData TweenRotate(this Component target, Vector3 targetEulerAngles, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformRotate tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformRotate>();

            TweenDataSequence tmpData = new TweenDataSequence(targetEulerAngles, duration, ease, null);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� ȸ����Ű�� �Լ�</summary>
        public static TweenData TweenRotate(this GameObject target, Vector3 targetEulerAngles, float duration, Ease ease = Ease.Constant)
        {
            return TweenRotate(target.transform, targetEulerAngles, duration, ease);
        }


        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� ũ�⸦ �����ϴ� �Լ�</summary>
        public static TweenData TweenScale(this Component target, Vector3 targetScale, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformScale tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformScale>();

            TweenDataSequence tmpData = new TweenDataSequence(targetScale, duration, ease, null);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� ũ�⸦ �����ϴ� �Լ�</summary>
        public static TweenData TweenScale(this GameObject target, Vector3 targetScale, float duration, Ease ease = Ease.Constant)
        {
            return TweenScale(target.transform, targetScale, duration, ease);
        }

        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� �����ϸ� �̵��ϴ� �Լ�</summary>
        public static TweenData TweenJump(this Component target, Vector3 targetPos, float jumpHeight, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenJump tweenData))
                tweenData = target.gameObject.AddComponent<TweenJump>();

            TweenDataSequence tmpData = new TweenDataSequence(targetPos, duration, ease, null);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);
            tweenData.SetHeight(jumpHeight);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� �����ϸ� �̵��ϴ� �Լ�</summary>
        public static TweenData TweenJump(this GameObject target, Vector3 targetPos, float jumpHeight, float duration, Ease ease = Ease.Constant)
        {
            return TweenJump(target, targetPos, jumpHeight, duration, ease);
        }


        /// <summary>��ǥ ������ ���� �ð����� UI ����� �����ϴ� �Լ�</summary>
        public static TweenData TweenSizeDelta(this RectTransform target, Vector2 targetSizeDelta, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenRectTransformSizeDelta tweenData))
                tweenData = target.gameObject.AddComponent<TweenRectTransformSizeDelta>();

            TweenDataSequence tmpData = new TweenDataSequence(targetSizeDelta, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� UI�� ��ġ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TweenAnchoredPosition(this RectTransform target, Vector2 targetAnchoredPosition, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenRectTransformAnchoredPosition tweenData))
                tweenData = target.gameObject.AddComponent<TweenRectTransformAnchoredPosition>();

            TweenDataSequence tmpData = new TweenDataSequence(targetAnchoredPosition, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� �ؽ�Ʈ �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenColor(this Text target, Color targetColor, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTextColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenTextColor>();

            TweenDataSequence tmpData = new TweenDataSequence(targetColor, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� �ؽ�Ʈ ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenAlpha(this Text target, float targetAlpha, float duration, Ease ease = Ease.Constant)
        {
            Color targetColor = new Color(target.color.r, target.color.g, target.color.b, targetAlpha);
            return TweenColor(target, targetColor, duration, ease);
        }


        /// <summary>��ǥ ������ ���� �ð����� Text.text ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenText(this Text target, string targetString, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTextContents tweenData))
                tweenData = target.gameObject.AddComponent<TweenTextContents>();

            TweenDataSequence tmpData = new TweenDataSequence(targetString, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ ������ �ѱ��� ��� �ð� * �� ���ڼ� ���� text�� �����ϴ� �Լ�</summary>
        public static TweenData TweenCharacter(this Text target, string targetString, float characterInterval, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTextContents tweenData))
                tweenData = target.gameObject.AddComponent<TweenTextContents>();

            float duration = targetString.Length * characterInterval;
            TweenDataSequence tmpData = new TweenDataSequence(targetString, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }




        /// <summary>��ǥ ������ ���� �ð����� TMP �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenColor(this TextMeshProUGUI target, Color targetColor, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTMPColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenTMPColor>();

            TweenDataSequence tmpData = new TweenDataSequence(targetColor, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� TMP ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenAlpha(this TextMeshProUGUI target, float targetAlpha, float duration, Ease ease = Ease.Constant)
        {
            Color targetColor = new Color(target.color.r, target.color.g, target.color.b, targetAlpha);
            return TweenColor(target, targetColor, duration, ease);
        }


        /// <summary>��ǥ ������ ���� �ð����� TMP.text�� �����ϴ� �Լ�</summary>
        public static TweenData TweenText(this TextMeshProUGUI target, string targetString, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTMPContents tweenData))
                tweenData = target.gameObject.AddComponent<TweenTMPContents>();

            TweenDataSequence tmpData = new TweenDataSequence(targetString, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ ������ �ѱ��� ��� �ð� * �� ���ڼ� ���� TMP.text�� �����ϴ� �Լ�</summary>
        public static TweenData TweenCharacter(this TextMeshProUGUI target, string targetString, float characterInterval, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenTMPContents tweenData))
                tweenData = target.gameObject.AddComponent<TweenTMPContents>();

            float duration = targetString.Length * characterInterval;
            TweenDataSequence tmpData = new TweenDataSequence(targetString, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� �̹��� �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenColor(this Image target, Color targetColor, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenImageColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenImageColor>();

            TweenDataSequence tmpData = new TweenDataSequence(targetColor, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� �̹��� ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenAlpha(this Image target, float targetAlpha, float duration, Ease ease = Ease.Constant)
        {
            Color targetColor = new Color(target.color.r, target.color.g, target.color.b, targetAlpha);
            return TweenColor(target, targetColor, duration, ease);
        }


        /// <summary>��ǥ ������ ���� �ð����� FillAmount ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenFillAmount(this Image target, float targetFill, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenImageFillAmount tweenData))
                tweenData = target.gameObject.AddComponent<TweenImageFillAmount>();

            TweenDataSequence tmpData = new TweenDataSequence(targetFill, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }



        /// <summary>��ǥ ������ ���� �ð����� ��������Ʈ ������ �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenColor(this SpriteRenderer target, Color targetColor, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenSpriteRendererColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenSpriteRendererColor>();

            TweenDataSequence tmpData = new TweenDataSequence(targetColor, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� ��������Ʈ ������ ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenAlpha(this SpriteRenderer target, float targetAlpha, float duration, Ease ease = Ease.Constant)
        {
            Color targetColor = new Color(target.color.r, target.color.g, target.color.b, targetAlpha);
            return TweenColor(target, targetColor, duration, ease);
        }


        /// <summary>��ǥ ������ ���� �ð����� ĵ���� �׷� ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenAlpha(this CanvasGroup target, float targetAlpha, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenCanvasGroupAlpha tweenData))
                tweenData = target.gameObject.AddComponent<TweenCanvasGroupAlpha>();

            TweenDataSequence tmpData = new TweenDataSequence(targetAlpha, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� LayoutGroup�� spacing ��ġ�� �����ϴ� �Լ�</summary>
        public static TweenData TweenSpacing(this HorizontalOrVerticalLayoutGroup target, float targetValue, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenLayoutGroupSpacing tweenData))
                tweenData = target.gameObject.AddComponent<TweenLayoutGroupSpacing>();

            TweenDataSequence tmpData = new TweenDataSequence(targetValue, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }


        /// <summary>��ǥ ������ ���� �ð����� ī�޶� ������ ���� �����ϴ� �Լ�</summary>
        public static TweenData TweenOrthographicSize(this Camera target, float targetSize, float duration, Ease ease = Ease.Constant)
        {
            if (!target.TryGetComponent(out TweenCameraSize tweenData))
                tweenData = target.gameObject.AddComponent<TweenCameraSize>();

            TweenDataSequence tmpData = new TweenDataSequence(targetSize, duration, ease, target);

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tmpData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

    }
}

