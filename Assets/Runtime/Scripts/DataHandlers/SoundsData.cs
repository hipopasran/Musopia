using System;
using UnityEngine;

namespace Musopia
{
    public class SoundsData : MonoBehaviour
    {
        public Action<SoundsData, bool> OnUpdate;

        private bool _isOn;
        [SerializeField]
        private ClipData _clipData;

        public AudioClip Clip => _clipData.Clip;
        public ClipData ClipData => _clipData;

        public void UpdateStatus()
        {
            _isOn = !_isOn;

            if (_clipData == null) return;

            OnUpdate?.Invoke(this, _isOn);
        }
    }
}