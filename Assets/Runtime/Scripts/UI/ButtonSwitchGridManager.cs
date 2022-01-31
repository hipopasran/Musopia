using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Musopia
{
    public class ButtonSwitchGridManager : MonoBehaviour
    {
        private ButtonSwitchGrid _currentButtonSelect;
        private List<ButtonSwitchGrid> _buttons = new List<ButtonSwitchGrid>();

        private void OnDestroy()
        {
            foreach(var item in _buttons)
            {
                item.OnSelect -= ButtonSelect;
            }
        }

        private void Awake()
        {
            var buttons = GetComponentsInChildren<ButtonSwitchGrid>();
            foreach (var item in buttons)
            {
                _buttons.Add(item);
                item.OnSelect += ButtonSelect;
            }
        }

        private void Start()
        {
            DeselectAll();

            _currentButtonSelect = _buttons[0];
            _currentButtonSelect.Select();

            ButtonSelect(_buttons[0]);
        }

        private void ButtonSelect(ButtonSwitchGrid selectButton)
        {
            if (_currentButtonSelect && _currentButtonSelect != selectButton)
                _currentButtonSelect.Deselect();

            _currentButtonSelect = selectButton;
            SequencerAudioManager.Instance.SelectCurrentGrid(_currentButtonSelect.Grid);
        }

        private void DeselectAll()
        {
            foreach (var item in _buttons)
            {
                item.Deselect();
            }
        }
    }
}
