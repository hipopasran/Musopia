using UnityEngine;
using System;

namespace Musopia
{
    [CreateAssetMenu(fileName ="ClipData", menuName ="Musopia/ClipData", order = 1)]
    public class ClipData : ScriptableObject
    {
        [SerializeField]
        private AudioClip _clip;

        public AudioClip Clip => _clip;
    }
}
