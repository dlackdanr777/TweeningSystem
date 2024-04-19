using System;
using System.Collections.Generic;
using UnityEngine;

namespace Muks.Tween
{
    /// <summary> Tween ������ ����� ���� Ŭ���� (�ݵ�� Tween.Sequence()�� ���� ����) </summary>
    public class Sequence
    {
        private LinkedList<SequenceData> _sequenceDataList = new LinkedList<SequenceData>();
        private List<TweenData> _currentTweenDataList = new List<TweenData>();
        private Action _currentCallback;
        private float _elapsedTime;
        private float _waitTime;

        private bool _isStart;
        private bool _isEnd;
        public bool IsEnd => _isEnd;


        /// <summary> ������ ���� �Լ�(���� �� ������ �߰�, ���� �Ұ���) </summary>
        public void Play()
        {
            SetData();
            _isStart = true;
        }


        /// <summary> Tween ����� ������ �� �ڿ� �߰� </summary>
        public Sequence Append(TweenData tweenData)
        {
            if (_isStart)
            {
                Debug.LogError("���� �������� ������ �Դϴ�.");
                return this;
            }

            tweenData.enabled = false;
            SequenceData data = new SequenceData();
            data.TweenDataList = new List<TweenData>{ tweenData };

            _sequenceDataList.AddLast(data);
            return this;
        }



        /// <summary> Tween ����� ���� ������ �������� Tween ��ɰ� ��ħ </summary>
        public Sequence Join(TweenData tweenData)
        {
            if (_isStart)
            {
                Debug.LogError("���� �������� ������ �Դϴ�.");
                return this;
            }

            if (_sequenceDataList.Last.Value.TweenDataList == null)
            {
                Debug.LogError("������ �������� Tween����� �������� �ʾ� Join�� �� �����ϴ�.");
                return this;
            }

            SequenceData data = _sequenceDataList.Last.Value;
            data.TweenDataList.Add(tweenData);
            tweenData.enabled = false;

            _sequenceDataList.RemoveLast();
            _sequenceDataList.AddLast(data);
            return this;
        }


        /// <summary> ��� ����� ������ �� �ڿ� �߰� </summary>
        public Sequence AppendInterval(float interval)
        {
            if (_isStart)
            {
                Debug.LogError("���� �������� ������ �Դϴ�.");
                return this;
            }

            SequenceData data = new SequenceData();
            data.WaitTime = interval;
            _sequenceDataList.AddLast(data);
            return this;
        }


        /// <summary> �ݹ� �Լ��� ���� ������ �������� �߰� </summary>
        public Sequence AppendCallback(Action callback)
        {
            if (_isStart)
            {
                Debug.LogError("���� �������� ������ �Դϴ�.");
                return this;
            }

            SequenceData data = _sequenceDataList.Last.Value;
            data.Callback = callback;

            _sequenceDataList.RemoveLast();
            _sequenceDataList.AddLast(data);
            return this;
        }


        /// <summary> Tween class���� ���� �������� ������Ʈ�ϱ� ���� �Լ� (���� ��� X) </summary>
        public void Update(float _deltaTime)
        {
            //�������� �ƴϰų� �������¸� ����
            if (!_isStart || _isEnd)
                return;

            //��� �ð� �������� �������̸� �����ð� ��� �� �ݹ� �� SetData()�� ���� �������� �ҷ���
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

            //Tween �������� �������̸�
            if (0 < _currentTweenDataList.Count)
            {
                _elapsedTime += _deltaTime;

                //�����ð� ������ ��� ����
                if (_elapsedTime < _deltaTime * 5)
                    return;

                //���������� TweenData�� ���ڸ�ŭ �ݺ�
                for (int i = 0, count = _currentTweenDataList.Count; i < count; i++)
                {

                    //����ð��� ������ �ʾ����� continue
                    if (_elapsedTime < _currentTweenDataList[i].TotalDuration)
                        continue;

                    //�̹� ���ᰡ ��ٸ�  continue
                    if (!_currentTweenDataList[i].enabled)
                        continue;
                    
                    //Tween���� �Ϸ� �븮�ڸ� �����ϸ� ��Ȱ��ȭ ��Ŵ
                    _currentTweenDataList[i].OnCompletedStart();
                    _currentTweenDataList[i].enabled = false;
                }

                //���� ���� ��Ȱ��ȭ ���¸� �Ʒ��� �Ѿ
                for (int i = 0, count = _currentTweenDataList.Count; i < count; i++)
                {
                    if (_currentTweenDataList[i].enabled)
                        return;
                }

                //������ �ݹ� ����� SetData()�� ���� ���� �������� �ҷ���
                _currentCallback?.Invoke();
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

