using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Musopia
{
    public class SequencerAudioManager : SingletonBehaviour<SequencerAudioManager>
    {
        private int _beatCountFull;
        private float _beatInterval;
        private float _beatTimer;

        private bool _beatFullColumn;
        private int _beatCountFullColumn;
        private float _beatIntervalColumn;
        private float _beatTimerColumn;

        private SequensorPullAudioSource _ausioSourcePull;

        [SerializeField]
        private float _bpm;
        [SerializeField]
        private int _columnCount;
        [SerializeField]
        private AudioSource _mainAudioSource;
        [SerializeField]
        private AudioMixerGroup _mixer;

        public List<ColumnData> data = new List<ColumnData>();

        public float ColumnCount => _columnCount;
        public int CurrentColumn => _beatCountFullColumn + 1;

        public void SelectCurrentGrid(GridData grid)
        {
            data = grid.Columns;
            _columnCount = data.Count;
        }

        private void Awake()
        {
            _ausioSourcePull = GetComponent<SequensorPullAudioSource>();
        }

        private void Update()
        {
            BeatDetection();
        }

        private void BeatDetection()
        {
            _beatInterval = 60 / _bpm;
            _beatTimer += Time.deltaTime;

            if(_beatTimer >= _beatInterval)
            {
                _beatTimer -= _beatInterval;
                _beatCountFull++;
            }

            _beatIntervalColumn = _beatInterval / _columnCount;
            _beatTimerColumn += Time.deltaTime;
            if(_beatTimerColumn >= _beatIntervalColumn)
            {
                var clips = data[_beatCountFullColumn].ActiveClips;
                if (clips.Count > 0)
                {
                    var source = _ausioSourcePull.GetSource().Source;
                    foreach (var item in clips)
                    {
                        source.PlayOneShot(item.Clip);
                    }
                }
                _beatTimerColumn -= _beatIntervalColumn;
                _beatCountFullColumn++;
                if(_beatCountFullColumn > data.Count - 1)
                {
                    _beatCountFullColumn = 0;
                }
            }

        }
    }
}
