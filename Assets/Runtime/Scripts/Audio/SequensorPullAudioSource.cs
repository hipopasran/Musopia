using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Musopia
{
    public class SequensorPullAudioSource : MonoBehaviour
    {
        [SerializeField]
        private int _sourcesStartCount;
        [SerializeField]
        private SequensorAudioSource _sourcePrefab;

        private Queue<SequensorAudioSource> _sourcesEnable = new Queue<SequensorAudioSource>();
        private List<SequensorAudioSource> _sourcesActive = new List<SequensorAudioSource>();

        public SequensorAudioSource GetSource()
        {
            SequensorAudioSource source = null;
            if (_sourcesEnable.Count > 0)
            {
                source = _sourcesEnable.Dequeue();
                source.gameObject.SetActive(true);
                _sourcesActive.Add(source);
                return source;
            }

            source = CreateNewSource();
            _sourcesActive.Add(source);
            return source;
        }

        private void Awake()
        {
            for (int i = 0; i < _sourcesStartCount; i++)
            {
                var source = CreateNewSource();
                source.gameObject.SetActive(false);
                _sourcesEnable.Enqueue(source);
            }
        }

        public void Update()
        {
            for(int i = 0; i < _sourcesActive.Count; i++)
            {
                var source = _sourcesActive[i];
                if(!source.Source.isPlaying)
                {
                    source.gameObject.SetActive(false);
                    _sourcesEnable.Enqueue(source);
                    _sourcesActive[i] = null;
                }
            }

            _sourcesActive.RemoveAll(x => x == null);
        }

        private SequensorAudioSource CreateNewSource()
        {
            var source = Instantiate(_sourcePrefab);
            source.transform.SetParent(this.transform);

            return source;
        }
    }
}
