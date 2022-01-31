using System.Collections.Generic;
using UnityEngine;

namespace Musopia
{
    public class ColumnData : MonoBehaviour
    {
        private List<SoundsData> _clipsData = new List<SoundsData>();
        private List<SoundsData> _activeClips = new List<SoundsData>();

        public List<SoundsData> ActiveClips => _activeClips;


        private void Awake()
        {
            var data = GetComponentsInChildren<SoundsData>();
            foreach(var item in data)
            {
                _clipsData.Add(item);
                item.OnUpdate += UpdateSoundStatus;
            }
        }

        private void OnDestroy()
        {
            foreach(var item in _clipsData)
            {
                item.OnUpdate -= UpdateSoundStatus;
            }
        }

        private void UpdateSoundStatus(SoundsData sound, bool status)
        {
            if (sound == null) return;

            if(status)
            {
                _activeClips.Add(sound);
            }
            else
            {
                if (!_activeClips.Contains(sound)) return;

                _activeClips.Remove(sound);
            }
        }
    }
}
