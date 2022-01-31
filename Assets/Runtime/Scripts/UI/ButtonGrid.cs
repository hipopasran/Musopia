using UnityEngine;
using UnityEngine.UI;

namespace Musopia
{
    public class ButtonGrid : MonoBehaviour
    {
        private bool _isActive;
        private Image _image;

        [SerializeField] private Sprite _imageDefault;
        [SerializeField] private Sprite _imageActive;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Click()
        {
            if (_image == null) return;

            if(_isActive)
            {
                _image.sprite = _imageDefault;
            }
            else
            {
                _image.sprite = _imageActive;
            }

            _isActive = !_isActive;
        }
    }
}
