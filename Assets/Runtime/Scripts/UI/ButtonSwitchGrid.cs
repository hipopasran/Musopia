using System;
using UnityEngine;
using UnityEngine.UI;

namespace Musopia
{
    public class ButtonSwitchGrid : MonoBehaviour
    {
        public Action<ButtonSwitchGrid> OnSelect;

        private Image _image;
        private GameObject _gridView;

        [Header("UI")]
        [SerializeField] private Sprite _imageDefault;
        [SerializeField] private Sprite _imageActive;
        [Header("Data")]
        [SerializeField] private GridData _grid;

        public GridData Grid => _grid;

        public void Deselect()
        {
            _image.sprite = _imageDefault;

            _gridView.SetActive(false);
        }

        private void Awake()
        {
            if (_grid == null)
            {
                Debug.LogError("Grid is empty!");
                return;
            }

            _image = GetComponent<Image>();
            _gridView = _grid.gameObject;
        }

        public void Select()
        {
            _image.sprite = _imageActive;
            _gridView.SetActive(true);

            OnSelect?.Invoke(this);
        }
    }
}
