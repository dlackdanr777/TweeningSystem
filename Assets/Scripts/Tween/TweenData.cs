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

        protected TweenMode _tweenMode;
        protected Queue<TweenDataSequence> _dataSequences = new Queue<TweenDataSequence>();
        protected Dictionary<TweenMode, Func<float, float, float>> _percentHandler;

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


        public virtual void SetData(TweenDataSequence dataSequence)
        {
            _currentDataSequenceId = dataSequence.Id;
            TotalDuration = dataSequence.Duration;
            _tweenMode = dataSequence.TweenMode;

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


        public void AddDataSequence(TweenDataSequence dataSequence)
        {
            //�븮�ڰ� ��� DataSequence�� ���� �߰��Ǵ��� Ȯ���ϱ� ���� Id�� �ο�
            dataSequence.Id = ++_dataSequenceIdCount;
            _dataSequences.Enqueue(dataSequence);
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


        /// <summary>Tween�� ��� �����͸� �ʱ�ȭ�ϴ� �Լ�</summary>
        public void Clear()
        {
            _dataSequences.Clear();

            _onStartedDic.Clear();
            _onStarted = null;
            _onCompletedDic.Clear();
            _onCompleted = null;
            _onUpdatedDic.Clear();
            _onUpdated = null;

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


        private void Awake()
        {
            _percentHandler = new Dictionary<TweenMode, Func<float, float, float>>
            {
                { TweenMode.Constant, Constant },
                {TweenMode.Quadratic, Quadratic },
                { TweenMode.Smoothstep, Smoothstep },
                { TweenMode.Smootherstep, Smootherstep },
                {TweenMode.Spike, Spike },
                {TweenMode.EaseInQuint, EaseInQuint },
                {TweenMode.EaseOutQuint, EaseOutQuint },
                {TweenMode.EaseInOutQuint, EaseInOutQuint },
                {TweenMode.EaseInExpo, EaseInExpo },
                {TweenMode.EaseOutExpo, EaseOutExpo },
                {TweenMode.EaseInOutExpo, EaseInOutExpo },
                {TweenMode.EaseInElastic, EaseInElastic },
                {TweenMode.EaseOutElastic, EaseOutElastic },
                {TweenMode.EaseInOutElastic, EaseInOutElastic },
                {TweenMode.EaseInBack, EaseInBack },
                {TweenMode.EaseOutBack, EaseOutBack },
                {TweenMode.EaseInOutBack, EaseInOutBack },
                {TweenMode.EaseInBounce, EaseInBounce },
                {TweenMode.EaseOutBounce, EaseOutBounce },
                {TweenMode.EaseInOutBounce, EaseInOutBounce },
                { TweenMode.Sinerp, Sinerp },
                { TweenMode.Coserp, Coserp }
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

                _onCompleted?.Invoke();
                _onCompleted = null;
                _onUpdated = null;

                //����� �ִϸ��̼ǵ��� ���� ��� ť���� �̾� �ִϸ��̼� ������ �ٽ� ���� �Ѵ�.
                if (0 < _dataSequences.Count)
                {
                    ElapsedDuration = 0;
                    SetData(_dataSequences.Dequeue());
                }
                else
                {
                    //�ƴ� ��� �Ϸ� �Լ� ������ ����
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
            float percent = elapsedDuration / totalDuration;

            return percent;
        }


        /// <summary> ���� � </summary>
        private float Quadratic(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = percent * percent;

            return percent;
        }


        /// <summary> ���� ������ ���� ���� ������ </summary>
        private float Smoothstep(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = percent * percent * (3f - 2f * percent);

            return percent;
        }


        /// <summary> ���� ������ ���� ���� ������(Smoothstep ���� �� ������) </summary>
        private float Smootherstep(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = percent * percent * percent * (percent * (6f * percent - 15f) + 10f);

            return percent;
        }


        /// <summary> ��ǥ ��ġ�� ���ٰ� �ٽ� ���� ��ġ�� �̵�</summary>
        private float Spike(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            if(elapsedDuration <= totalDuration * 0.5f)
                return  Mathf.Pow(percent/ 0.5f, 3);

            return Mathf.Pow((1 - percent) / 0.5f, 3);
        }


        private float EaseInQuint(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;

            return percent * percent * percent * percent * percent;
        }


        private float EaseOutQuint(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;

            return 1 - Mathf.Pow((1 - percent), 5);
        }


        private float EaseInOutQuint(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;

            return percent < 0.5f ? 16 * percent * percent * percent * percent * percent
                : 1 - Mathf.Pow(-2 * percent + 2, 5) / 2;
        }


        private float EaseInExpo(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;

            return percent == 0 ? 0 : Mathf.Pow(2, 10 * percent - 10);
        }


        private float EaseOutExpo(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;

            return percent == 1 ? 1 : 1 - Mathf.Pow(2, -10 * percent);
        }


        private float EaseInOutExpo(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;

            float returnValue = percent == 0
                ? 0
                : percent == 1
                ? 1
                : percent < 0.5f ? Mathf.Pow(2, 20 * percent - 10) / 2
                : (2 - Mathf.Pow(2, -20 * percent + 10)) / 2;

            return returnValue;
        }


        private float EaseInElastic(float elapsedDuration, float totalDuration)
        {
            float c = (2 * Mathf.PI) / 3f;
            float percent = elapsedDuration / totalDuration;

            return percent == 0 ? 0 : percent == 1 ?
                1: -Mathf.Pow(2, 10 * percent - 10) * Mathf.Sin((percent * 10 - 10.75f) * c);
        }


        private float EaseOutElastic(float elapsedDuration, float totalDuration)
        {
            float c = (2 * Mathf.PI) / 3f;
            float percent = elapsedDuration / totalDuration;

            return percent == 0 ? 0 : percent == 1 ?
                1 : Mathf.Pow(2, -10 * percent) * Mathf.Sin((percent * 10 - 0.75f) * c) + 1;
        }


        private float EaseInOutElastic(float elapsedDuration, float totalDuration)
        {
            float c = (2 * Mathf.PI) / 4.5f;
            float percent = elapsedDuration / totalDuration;

            return percent == 0 ? 0 : percent == 1 ? 1 : percent < 0.5f
            ? -(Mathf.Pow(2, 20 * percent - 10) * Mathf.Sin((20 * percent - 11.125f) * c)) / 2
            : (Mathf.Pow(2, -20 * percent + 10) * Mathf.Sin((20 * percent - 11.125f) * c)) / 2 + 1;
        }


        private float EaseInBack(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            float c1 = 1.70158f;
            float c2 = c1 + 1f;

            return c2 * percent * percent * percent - c1 * percent * percent;
        }


        private float EaseOutBack(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            float c1 = 1.70158f;
            float c2 = c1 + 1f;

            return 1 + c2 * Mathf.Pow(percent - 1, 3) + c1 * Mathf.Pow(percent - 1, 2);
        }


        private float EaseInOutBack(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            float c1 = 1.70158f;
            float c2 = c1 * 1.525f;

            return percent < 0.5f
               ? (Mathf.Pow(2 * percent, 2) * ((c2 + 1) * 2 * percent - c2)) / 2
               : (Mathf.Pow(2 * percent - 2, 2) * ((c2 + 1) * (percent * 2 - 2) + c2) + 2) / 2;
        }


        private float EaseInBounce(float elapsedDuration, float totalDuration)
        {
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


        private float EaseOutBounce(float elapsedDuration, float totalDuration)
        {
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


        private float EaseInOutBounce(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;

            return percent < 0.5f
               ? (1 - EaseOutBounce(1 - 2 * percent)) / 2
               : (1 + EaseOutBounce(2 * percent - 1)) / 2;
        }


        //sin�׷���ó�� ������
        private float Sinerp(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = Mathf.Sin(percent * Mathf.PI * 0.5f);

            return percent;
        }


        //cos�׷���ó�� ������
        private float Coserp(float elapsedDuration, float totalDuration)
        {
            float percent = elapsedDuration / totalDuration;
            percent = Mathf.Cos(percent * Mathf.PI * 0.5f);

            return percent;
        }
    }
}
