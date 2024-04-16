using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Muks.Tween
{
    public class Sequence
    {
        private LinkedList<SequenceData> _sequenceDataList = new LinkedList<SequenceData>();
        private float _elapsedTime;

        private List<TweenData> _currentTweenDataList = new List<TweenData>();
        private Action _currentCallback;
        private float _waitTime;

        private bool _isStart;
        private bool _isEnd;
        public bool IsEnd => _isEnd;


        public void Play()
        {
            SetData();
            _isStart = true;
        }


        public Sequence Append(TweenData tweenData)
        {
            if (_isStart)
                return this;

            tweenData.enabled = false;
            SequenceData data = new SequenceData();
            data.TweenDataList = new List<TweenData>{ tweenData };

            _sequenceDataList.AddLast(data);
            return this;
        }


        public Sequence Join(TweenData tweenData)
        {
            if (_isStart)
                return this;

            if (_sequenceDataList.Last.Value.TweenDataList == null)
                return this;

            SequenceData data = _sequenceDataList.Last.Value;
            data.TweenDataList.Add(tweenData);

            _sequenceDataList.RemoveLast();
            _sequenceDataList.AddLast(data);
            return this;
        }


        public Sequence AppendInterval(float interval)
        {
            if (_isStart)
                return this;

            SequenceData data = new SequenceData();
            data.WaitTime = interval;
            _sequenceDataList.AddLast(data);
            return this;
        }


        public Sequence AppendCallback(Action callback)
        {
            if (_isStart)
                return this;

            SequenceData data = _sequenceDataList.Last.Value;
            data.Callback = callback;

            _sequenceDataList.RemoveLast();
            _sequenceDataList.AddLast(data);
            return this;
        }


        internal void Update(float _deltaTime)
        {
            if (!_isStart || _isEnd)
                return;


            if (0 < _waitTime)
            {
                _elapsedTime += _deltaTime;

                if(_waitTime <= _elapsedTime)
                {
                    _currentCallback?.Invoke();
                    SetData();
                    return;
                }

                return;
            }

            if (0 < _currentTweenDataList.Count)
            {
                bool isEnabled = false;

                for(int i = 0, count = _currentTweenDataList.Count; i < count; i++)
                {
                    if (!_currentTweenDataList[i].enabled)
                        continue;

                    isEnabled = true;
                    break;
                }
                if (isEnabled)
                    return;

                _currentCallback?.Invoke();
                for (int i = 0, count = _currentTweenDataList.Count; i < count; i++)
                {
                    _currentTweenDataList[i].enabled = false;
                }
                SetData();
            }
        }


        private void SetData()
        {
            if (_sequenceDataList.Count <= 0)
            {
                _isEnd = true;
                return;
            }

            SequenceData currentSequenceData = _sequenceDataList.First.Value;
            _sequenceDataList.RemoveFirst();

            _elapsedTime = 0;
            _currentTweenDataList.Clear();
            _currentCallback = null;
            _waitTime = currentSequenceData.WaitTime;


            if (currentSequenceData.TweenDataList != null)
            {
                _currentTweenDataList = currentSequenceData.TweenDataList;
                for (int i = 0, count = _currentTweenDataList.Count; i < count; i++)
                {
                    _currentTweenDataList[i].enabled = true;
                }
            }

            if(currentSequenceData.Callback != null)
            {
                _currentCallback = currentSequenceData.Callback;
            }


        }
    }
}

