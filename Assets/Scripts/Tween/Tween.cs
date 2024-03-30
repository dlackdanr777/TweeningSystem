using System;
using System.Collections.Generic;
using UnityEngine;

namespace Muks.Tween
{

    /// <summary>Ʈ�� �ִϸ��̼��� ���� ���� Ŭ����</summary>
    public static class Tween
    {

        /// <summary>�ش� ������Ʈ�� �Ͻ������� ��� Tween ���� �Լ�</summary>
        public static void Play(Component target)
        {
            TweenData[] tweens = target.GetComponents<TweenData>();

            foreach (TweenData tween in tweens)
            {
                tween.enabled = true;
            }
        }

        /// <summary>�ش� ������Ʈ�� �Ͻ������� ��� Tween ���� �Լ�</summary>
        public static void Play(GameObject target)
        {
            Play(target.transform);
        }


        /// <summary>�ش� ������Ʈ�� ��� Tween ���� �Լ�</summary>
        public static void Stop(Component target)
        {
            TweenData[] tweens = target.GetComponents<TweenData>();

            foreach (TweenData tween in tweens)
            {
                tween.Clear();
            }
        }

        /// <summary>�ش� ������Ʈ�� ��� Tween ���� �Լ�</summary>
        public static void Stop(GameObject target)
        {
            Stop(target.transform);
        }


        /// <summary>�ش� ������Ʈ�� ��� Tween �Ͻ� ���� �Լ�(Play() ȣ�� ������ ����)</summary>
        public static void Pause(Component target)
        {
            TweenData[] tweens = target.GetComponents<TweenData>();

            foreach (TweenData tween in tweens)
            {
                tween.enabled = false;
            }
        }

        /// <summary>�ش� ������Ʈ�� ��� Tween �Ͻ� ���� �Լ�(Play() ȣ�� ������ ����)</summary>
        public static void Pause(GameObject target)
        {
            Pause(target.transform);
        }


        //===================================== �̰����� �ִϸ��̼� ���� �Լ� =====================================//

        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� �̵���Ű�� �Լ�</summary>
        public static TweenData TransformMove(Component target, Vector3 targetPosition, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformMove tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformMove>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetPosition;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData TransformMove(GameObject target, Vector3 targetPosition, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return TransformMove(target.transform, targetPosition, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� ȸ����Ű�� �Լ�</summary>
        public static TweenData TransformRotate(Component target, Vector3 targetEulerAngles, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformRotate tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformRotate>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetEulerAngles;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData TransformRotate(GameObject target, Vector3 targetEulerAngles, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return TransformRotate(target.transform, targetEulerAngles, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� ������Ʈ�� ũ�⸦ �����ϴ� �Լ�</summary>
        public static TweenData TransformScale(Component target, Vector3 targetScale, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenTransformScale tweenData))
                tweenData = target.gameObject.AddComponent<TweenTransformScale>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetScale;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData TransformScale(GameObject target, Vector3 targetScale, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return TransformScale(target.transform, targetScale, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� UI ����� �����ϴ� �Լ�</summary>
        public static TweenData RectTransfromSizeDelta(Component target, Vector2 targetSizeDelta, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenRectTransformSizeDelta tweenData))
                tweenData = target.gameObject.AddComponent<TweenRectTransformSizeDelta>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetSizeDelta;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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

        /// <summary>��ǥ ������ ���� �ð����� UI ����� �����ϴ� �Լ�</summary>
        public static TweenData RectTransfromSizeDelta(GameObject target, Vector2 targetSizeDelta, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return RectTransfromSizeDelta(target.transform, targetSizeDelta, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� UI�� ��ġ�� �̵���Ű�� �Լ�</summary>
        public static TweenData RectTransfromAnchoredPosition(Component target, Vector2 targetAnchoredPosition, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenRectTransformAnchoredPosition tweenData))
                tweenData = target.gameObject.AddComponent<TweenRectTransformAnchoredPosition>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetAnchoredPosition;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData RectTransfromAnchoredPosition(GameObject target, Vector2 targetAnchoredPosition, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return RectTransfromAnchoredPosition(target.transform, targetAnchoredPosition, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� �ؽ�Ʈ �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData TextColor(Component target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenTextColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenTextColor>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetColor;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData TextColor(GameObject target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return TextColor(target.transform, targetColor, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� �ؽ�Ʈ ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData TextAlpha(Component target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenTextAlpha tweenData))
                tweenData = target.gameObject.AddComponent<TweenTextAlpha>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetAlpha;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData TextAlpha(GameObject target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return TextAlpha(target.transform, targetAlpha, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� TMP �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData TMPColor(Component target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenTMPColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenTMPColor>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetColor;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData TMPColor(GameObject target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return TMPColor(target.transform, targetColor, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� TMP ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData TMPAlpha(Component target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenTMPAlpha tweenData))
                tweenData = target.gameObject.AddComponent<TweenTMPAlpha>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetAlpha;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData TMPAlpha(GameObject target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return TMPAlpha(target.transform, targetAlpha, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� �̹��� �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData IamgeColor(Component target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenImageColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenImageColor>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetColor;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;

            tweenData.IsLoop = false;
            tweenData.AddDataSequence(tempData);

            if (!tweenData.enabled)
            {
                tweenData.ElapsedDuration = 0;
                tweenData.TotalDuration = 0;
                tweenData.enabled = true;
            }

            return tweenData;
        }

        /// <summary>��ǥ ������ ���� �ð����� �̹��� �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData IamgeColor(GameObject target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return IamgeColor(target.transform, targetColor, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� �̹��� ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData IamgeAlpha(Component target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenImageAlpha tweenData))
                tweenData = target.gameObject.AddComponent<TweenImageAlpha>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetAlpha;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData IamgeAlpha(GameObject target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return IamgeAlpha(target.transform, targetAlpha, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� ��������Ʈ ������ �÷� ���� �����ϴ� �Լ�</summary>
        public static TweenData SpriteRendererColor(Component target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenSpriteRendererColor tweenData))
                tweenData = target.gameObject.AddComponent<TweenSpriteRendererColor>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetColor;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData SpriteRendererColor(GameObject target, Color targetColor, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return SpriteRendererColor(target.transform, targetColor, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� ��������Ʈ ������ ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData SpriteRendererAlpha(Component target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenSpriteRendererAlpha tweenData))
                tweenData = target.gameObject.AddComponent<TweenSpriteRendererAlpha>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetAlpha;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData SpriteRendererAlpha(GameObject target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return SpriteRendererAlpha(target.transform, targetAlpha, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� ĵ���� �׷� ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData CanvasGroupAlpha(Component target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenCanvasGroupAlpha tweenData))
                tweenData = target.gameObject.AddComponent<TweenCanvasGroupAlpha>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetAlpha;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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

        /// <summary>��ǥ ������ ���� �ð����� ĵ���� �׷� ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData CanvasGroupAlpha(GameObject target, float targetAlpha, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return CanvasGroupAlpha(target.transform, targetAlpha, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� LayoutGroup�� spacing ��ġ�� �����ϴ� �Լ�</summary>
        public static TweenData LayoutGroupSpacing(Component target, float targetValue, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenLayoutGroupSpacing tweenData))
                tweenData = target.gameObject.AddComponent<TweenLayoutGroupSpacing>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetValue;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData LayoutGroupSpacing(GameObject target, float targetValue, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return LayoutGroupSpacing(target.transform, targetValue, duration, tweenMode);
        }


        /// <summary>��ǥ ������ ���� �ð����� ī�޶� ������ ���� �����ϴ� �Լ�</summary>
        public static TweenData CameraOrthographicSize(Component target, float targetSize, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            if (!target.TryGetComponent(out TweenCameraSize tweenData))
                tweenData = target.gameObject.AddComponent<TweenCameraSize>();

            DataSequence tmpData = new DataSequence();
            tmpData.TargetValue = targetSize;
            tmpData.Duration = duration;
            tmpData.TweenMode = tweenMode;

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
        public static TweenData CameraOrthographicSize(GameObject target, float targetSize, float duration, TweenMode tweenMode = TweenMode.Constant)
        {
            return CameraOrthographicSize(target.transform, targetSize, duration, tweenMode);
        }


     /*   /// <summary>��ǥ ������ ���� �ð����� 2D Light ���� ���� �����ϴ� �Լ�</summary>
        public static TweenData Light2DIntensity(GameObject targetObject, float targetIntensity, float duration, TweenMode tweenMode = TweenMode.Constant, Action onComplete = null, Action onUpdate = null)
        {
            TweenLight2DIntensity objToLight2D = !targetObject.GetComponent<TweenLight2DIntensity>()
                ? targetObject.AddComponent<TweenLight2DIntensity>()
                : targetObject.GetComponent<TweenLight2DIntensity>();

            DataSequence tempData = new DataSequence();
            tempData.TargetValue = targetIntensity;
            tempData.Duration = duration;
            tempData.TweenMode = tweenMode;
            tempData.OnComplete = onComplete;
            tempData.OnUpdate = onUpdate;

            objToLight2D.IsLoop = false;
            objToLight2D.AddDataSequence(tempData);

            if (!objToLight2D.enabled)
            {
                objToLight2D.ElapsedDuration = 0;
                objToLight2D.TotalDuration = 0;
                objToLight2D.enabled = true;
            }

            return objToLight2D;
        }*/

    }
}
