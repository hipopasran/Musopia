using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Musopia
{
    public class SequensorAudioSource : MonoBehaviour
    {
        private AudioSource _source;

        public AudioSource Source => _source;

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }
    }
}
