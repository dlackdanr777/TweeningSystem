using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Muks.Tween
{

    public class TweenData : MonoBehaviour
    {

        internal float ElapsedDuration; // ���� ��� �ð�
        internal float TotalDuration; //�� �ð�
        internal bool IsLoop; //�ݺ� ����

        protected Ease _tweenMode;
        protected Queue<TweenDataSequence> _dataSequences = new Queue<TweenDataSequence>();
        protected Dictionary<Ease, Func<float, float, float>> _percentHandler;

        private bool _isRightMove = true;
        private LoopType _loopType;

        private Action _onUpdated;
        private Action _onStarted;
        private Action _onCompleted;
        private Dictionary<int, Action> _onUpdatedDic = new Dictionary<int, Action>();
        private Dictionary<int, Action> _onStartedDic = new Dictionary<int, Action>();
        private Dictionary<int, Action> _onCompletedDic = new Dictionary<int, Action>();
        private int _currentDataSequenceId;
        private int _dataSequenceIdCount = -1;

        /// <summary>Tween�� ��� �����͸� �ʱ�ȭ�ϴ� �Լ�</summary>
        public virtual void Clear()
        {
            _dataSequences.Clear();
            _onStartedDic.Clear();
            _onStarted = null;
            _onCompletedDic.Clear();
            _onCompleted = null;
            _onUpdatedDic.Clear();
            _onUpdated = null;

            ElapsedDuration = 0;
            TotalDuration = 0;

            IsLoop = false;
            enabled = false;
        }


        /// <summary>�ִϸ��̼� ���۽� ����Ǵ� �븮�ڸ� �޴� �Լ�</summary>
        public TweenData OnStart(Action onStarted)
        {
            _onStartedDic.Add(_dataSequenceIdCount, onStarted);
            return this;
        }


        /// <summary>�ִϸ��̼� ������ ����Ǵ� �븮�ڸ� �޴� �Լ�</summary>
        public TweenData OnComplete(Action onCompleted)
        {
            _onCompletedDic.Add(_dataSequenceIdCount, onCompleted);
            return this;
        }


        /// <summary>�ִϸ��̼� ������ �ݺ������� ����Ǵ� �븮�ڸ� �޴� �Լ�</summary>
        public TweenData OnUpdate(Action onUpdated)
        {
            _onUpdatedDic.Add(_dataSequenceIdCount, onUpdated);
            return this;
        }


        /// <summary>���� �ݺ�</summary>
        public void Loop(LoopType loopType = LoopType.Restart)
        {
            TweenDataSequence sequence = _dataSequences.Last();
            _dataSequences.Clear();
            _dataSequences.Enqueue(sequence);
            SetData(_dataSequences.Dequeue());
            _loopType = loopType;
            IsLoop = true;
        }


        /// <summary>�ݺ� Ƚ�� ����</summary>
        public void Repeat(int count)
        {
            TweenDataSequence sequence = _dataSequences.Last();

            for (int i = 1; i < count; i++)
            {
                AddDataSequence(sequence);
            }
        }


        protected virtual void SetData(TweenDataSequence dataSequence)
        {
            _currentDataSequenceId = dataSequence.Id;
            TotalDuration = dataSequence.Duration;
            _tweenMode = dataSequence.Ease;

            //�ش� �ִϸ��̼� id���� ���� id�� ���� �븮�ڰ� ������ ��� ������ �븮�� ����
            if (_onUpdatedDic.TryGetValue(dataSequence.Id, out _onUpdated))
                _onUpdatedDic.Remove(dataSequence.Id);
            else
                _onUpdated = null;

            //�ش� �ִϸ��̼� id���� ���� id�� ���� �븮�ڰ� ������ ��� ���� �븮�� ����
            if (_onStartedDic.TryGetValue(_currentDataSequenceId, out _onStarted))
            {
                _onStarted?.Invoke();
                _onStartedDic.Remove(_currentDataSequenceId);
            }

            //�ش� �ִϸ��̼� id���� ���� id�� ���� �븮�ڰ� ������ ��� �Ϸ� �븮�� ����
            if (_onCompletedDic.TryGetValue(_currentDataSequenceId, out _onCompleted))
            {
                _onCompletedDic.Remove(_currentDataSequenceId);
            }
            else
            {
                _onCompleted = null;
            }

        }


        internal void AddDataSequence(TweenDataSequence dataSequence)
        {
            //�븮�ڰ� ��� DataSequence�� ���� �߰��Ǵ��� Ȯ���ϱ� ���� Id�� �ο�
            dataSequence.SetId(++_dataSequenceIdCount);
            _dataSequences.Enqueue(dataSequence);
        }


        /// <summary> ���� �Ϸ� �븮�ڸ� �����ϰ� null������ �����ϴ� �Լ� </summary>
        internal void OnCompletedStart()
        {
            _onCompleted?.Invoke();
            _onCompleted = null;
        }


        private void Awake()
        {
            _percentHandler = new Dictionary<Ease, Func<float, float, float>>
            {
                { Ease.Constant, Constant },
                { Ease.Smoothstep, Smoothstep },
                { Ease.Smootherstep, Smootherstep },
                { Ease.Spike, Spike },
                { Ease.InSine, InSine },
                { Ease.OutSine, OutSine },
                { Ease.InOutSine, InOutSine },
                { Ease.InQuad, InQuad },
                { Ease.OutQuad, OutQuad },
                { Ease.InOutQuad, InOutQuad },
                { Ease.InQuint, InQuint },
                { Ease.OutQuint, OutQuint },
                { Ease.InOutQuint, InOutQuint },
                { Ease.InExpo, InExpo },
                { Ease.OutExpo, OutExpo },
                { Ease.InOutExpo, InOutExpo },
                { Ease.InCirc, InCirc },
                { Ease.OutCirc, OutCirc },
                { Ease.InOutCirc, InOutCirc },
                { Ease.InElastic, InElastic },
                { Ease.OutElastic, OutElastic },
                { Ease.InOutElastic, InOutElastic },
                { Ease.InBack, InBack },
                { Ease.OutBack, OutBack },
                { Ease.InOutBack, InOutBack },
                { Ease.InBounce, InBounce },
                { Ease.OutBounce, OutBounce },
                { Ease.InOutBounce, InOutBounce },
                { Ease.InCubic, InCubic },
                { Ease.OutCubic, OutCubic },
                { Ease.InOutCubic, InOutCubic },
            };
        }


        protected virtual void Update()
        {
            _onUpdated?.Invoke();

            //���� �ݺ� ������ �Ǿ��ִٸ�?
            if (IsLoop)
            {
                switch (_loopType)
                {
                    case LoopType.Restart:
                        ElapsedDuration += Time.deltaTime;
                        ElapsedDuration = Mathf.Clamp(ElapsedDuration, 0, TotalDuration);

                        if (TotalDuration <= ElapsedDuration)
                        {
                            ElapsedDuration = 0;
                            _onCompleted?.Invoke();
                        }

                        break;

                    case LoopType.Yoyo:
                        ElapsedDuration += _isRightMove ? Time.deltaTime : -Time.deltaTime;
                        ElapsedDuration = Mathf.Clamp(ElapsedDuration, 0, TotalDuration);

                        if (_isRightMove && TotalDuration <= ElapsedDuration)
                        {
                            _isRightMove = false;
                            _onCompleted?.Invoke();
                        }
                        else if (!_isRightMove && ElapsedDuration <= 0)
                        {
                            _isRightMove = true;
                            _onCompleted?.Invoke();
                        }
                        break;
                }
            }

            else
            {
                ElapsedDuration += Time.deltaTime;
                ElapsedDuration = Mathf.Clamp(ElapsedDuration, 0, TotalDuration);

                //���� ��� �ð��� �� ����ð��� ���� �ʾ��� ��� ����
                if (ElapsedDuration < TotalDuration)
                    return;

                //�� ����ð��� �Ѿ��� ��� �ݹ� �Լ� ���� �� �ʱ�ȭ
                _onCompleted?.Invoke();
                _onCompleted = null;
                _onUpdated = null;

                //����� �ִϸ��̼ǵ��� ���� ��� ť���� �̾� �ִϸ��̼� ������ �ٽ� ���� �Ѵ�.
                if (0 < _dataSequences.Count)
                {
                    ElapsedDuration = 0;
                    SetData(_dataSequences.Dequeue());
                }
                //���� ��� �Ϸ� �Լ� ������ ����
                else
                {
                    TweenCompleted();
                    enabled = false;
                }
            }
        }


        /// <summary>Tween�ִϸ��̼��� ����� ��� �ҷ����� �Լ� </summary>
        protected virtual void TweenCompleted()
        {
        }


        /// <summary> ��� � </summary>
        private float Constant(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent;
        }


        /// <summary> ���� ������ ���� ���� ������ </summary>
        private float Smoothstep(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            percent = percent * percent * (3f - 2f * percent);

            return percent;
        }


        /// <summary> ���� ������ ���� ���� ������(Smoothstep ���� �� ������) </summary>
        private float Smootherstep(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            percent = percent * percent * percent * (percent * (6f * percent - 15f) + 10f);
            return percent;
        }


        /// <summary> ��ǥ ��ġ�� ���ٰ� �ٽ� ���� ��ġ�� �̵�</summary>
        private float Spike(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            if(elapsedDuration <= totalDuration * 0.5f)
                return  Mathf.Pow(percent/ 0.5f, 3);

            return Mathf.Pow((1 - percent) / 0.5f, 3);
        }


        /// <summary> ���� ������ </summary>
        private float InQuad(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            percent = 1 - (1 - percent) * (1 - percent);

            return percent;
        }


        /// <summary> ���� �����ٰ� ���� ������ </summary>
        private float InOutQuad(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            percent = percent < 0.5f ? 2 * percent * percent : 1 - Mathf.Pow(-2 * percent + 2, 2) / 2;

            return percent;
        }



        /// <summary> ���� ������ </summary>
        private float OutQuad(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            percent = percent * percent;

            return percent;
        }


        private float InQuint(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent * percent * percent * percent * percent;
        }


        private float OutQuint(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return 1 - Mathf.Pow((1 - percent), 5);
        }


        private float InOutQuint(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent < 0.5f ? 16 * percent * percent * percent * percent * percent
                : 1 - Mathf.Pow(-2 * percent + 2, 5) / 2;
        }


        private float InExpo(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent == 0 ? 0 : Mathf.Pow(2, 10 * percent - 10);
        }


        private float OutExpo(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent == 1 ? 1 : 1 - Mathf.Pow(2, -10 * percent);
        }


        private float InOutExpo(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;

            float returnValue = percent == 0
                ? 0
                : percent == 1
                ? 1
                : percent < 0.5f ? Mathf.Pow(2, 20 * percent - 10) / 2
                : (2 - Mathf.Pow(2, -20 * percent + 10)) / 2;

            return returnValue;
        }


        private float InElastic(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float c = (2 * Mathf.PI) / 3f;
            float percent = elapsedDuration / totalDuration;

            return percent == 0 ? 0 : percent == 1 ?
                1: -Mathf.Pow(2, 10 * percent - 10) * Mathf.Sin((percent * 10 - 10.75f) * c);
        }


        private float OutElastic(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float c = (2 * Mathf.PI) / 3f;
            float percent = elapsedDuration / totalDuration;

            return percent == 0 ? 0 : percent == 1 ?
                1 : Mathf.Pow(2, -10 * percent) * Mathf.Sin((percent * 10 - 0.75f) * c) + 1;
        }


        private float InOutElastic(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float c = (2 * Mathf.PI) / 4.5f;
            float percent = elapsedDuration / totalDuration;

            return percent == 0 ? 0 : percent == 1 ? 1 : percent < 0.5f
            ? -(Mathf.Pow(2, 20 * percent - 10) * Mathf.Sin((20 * percent - 11.125f) * c)) / 2
            : (Mathf.Pow(2, -20 * percent + 10) * Mathf.Sin((20 * percent - 11.125f) * c)) / 2 + 1;
        }


        private float InBack(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            float c1 = 1.70158f;
            float c2 = c1 + 1f;

            return c2 * percent * percent * percent - c1 * percent * percent;
        }


        private float OutBack(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            float c1 = 1.70158f;
            float c2 = c1 + 1f;

            return 1 + c2 * Mathf.Pow(percent - 1, 3) + c1 * Mathf.Pow(percent - 1, 2);
        }


        private float InOutBack(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;

            return percent < 0.5f
               ? (Mathf.Pow(2 * percent, 2) * ((c2 + 1) * 2 * percent - c2)) / 2
               : (Mathf.Pow(2 * percent - 2, 2) * ((c2 + 1) * (percent * 2 - 2) + c2) + 2) / 2;
        }


        private float InBounce(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return 1 - EaseOutBounce(1 - percent);
        }


        private float EaseOutBounce(float percent)
        {

            float n1 = 7.5625f;
            float d1 = 2.75f;
            if (percent < 1 / d1)
            {
                return n1 * percent * percent;
            }
            else if (percent < 2 / d1)
            {
                return n1 * (percent -= 1.5f / d1) * percent + 0.75f;
            }
            else if (percent < 2.5f / d1)
            {
                return n1 * (percent -= 2.25f / d1) * percent + 0.9375f;
            }
            else
            {
                return n1 * (percent -= 2.625f / d1) * percent + 0.984375f;
            }
        }


        private float OutBounce(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;

            float n1 = 7.5625f;
            float d1 = 2.75f;
            if (percent < 1 / d1)
            {
                return n1 * percent * percent;
            }
            else if (percent < 2 / d1)
            {
                return n1 * (percent -= 1.5f / d1) * percent + 0.75f;
            }
            else if (percent < 2.5f / d1)
            {
                return n1 * (percent -= 2.25f / d1) * percent + 0.9375f;
            }
            else
            {
                return n1 * (percent -= 2.625f / d1) * percent + 0.984375f;
            }
        }


        private float InOutBounce(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;

            return percent < 0.5f
               ? (1 - EaseOutBounce(1 - 2 * percent)) / 2
               : (1 + EaseOutBounce(2 * percent - 1)) / 2;
        }


        private float InCubic(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent * percent * percent;
        }

        private float OutCubic(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return 1 - Mathf.Pow(1 - percent, 3);
        }


        private float InOutCubic(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent < 0.5f ? 4 * percent * percent * percent : 1 - Mathf.Pow(-2 * percent + 2, 3) / 2;
        }


        //sin�׷���ó�� ������
        private float Sinerp(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            percent = Mathf.Sin(percent * Mathf.PI * 0.5f);

            return percent;
        }


        //cos�׷���ó�� ������
        private float Coserp(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            percent = Mathf.Cos(percent * Mathf.PI * 0.5f);

            return percent;
        }


        private float InCirc(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(percent, 2));
        }


        private float OutCirc(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return Mathf.Sqrt(1 - Mathf.Pow(percent - 1, 2));
        }


        private float InOutCirc(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return percent < 0.5f ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * percent, 2))) / 2
                : (Mathf.Sqrt(1 - Mathf.Pow(-2 * percent + 2, 2))) / 2;
        }


        private float InSine(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return 1 - Mathf.Cos((percent * Mathf.PI) / 2);
        }


        private float OutSine(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return Mathf.Sin((percent * Mathf.PI) / 2);
        }


        private float InOutSine(float elapsedDuration, float totalDuration)
        {
            if (totalDuration <= 0)
                return 0;

            float percent = elapsedDuration / totalDuration;
            return -(Mathf.Cos(Mathf.PI * percent) - 1) / 2;
        }
    }
}
