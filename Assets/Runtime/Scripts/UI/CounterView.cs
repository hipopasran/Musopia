using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Musopia
{
    public class CounterView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _counter;

        private void Update()
        {
            _counter.text = SequencerAudioManager.Instance.CurrentColumn.ToString() + "/" + SequencerAudioManager.Instance.ColumnCount.ToString();
        }
    }
}
