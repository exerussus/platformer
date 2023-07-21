using UnityEngine;

namespace Source.Scripts.KeyListeners
{
    public class ButtonListener : MonoBehaviour
    {
        private bool _isPressed = false;

        public void Press()
        {
            _isPressed = true;
        }

        public bool GetButtonDown()
        {
            var isPressed = _isPressed;
            _isPressed = false;
            return isPressed;
        }
    }
}