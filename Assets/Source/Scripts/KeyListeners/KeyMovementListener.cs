using System;
using UnityEngine;

namespace Source.Scripts.KeyListeners
{
    public abstract class KeyMovementListener : MonoBehaviour
    {
        private float _axisV;
        private float _axisH;
        private bool _isStealthModOn;

        public Action<float, float, bool> OnAxisChange;
        public Action OnJump;

        protected abstract float SetAxisV();
        protected abstract float SetAxisH();
        protected abstract bool SwitchStealthMode();
        protected abstract bool GetPressedJump();
    
        private void Update()
        {
            _axisV = SetAxisV();
            _axisH = SetAxisH();
            if (SwitchStealthMode()) _isStealthModOn = !_isStealthModOn;
        }

        private void FixedUpdate()
        {
            OnAxisChange?.Invoke(_axisV, _axisH, _isStealthModOn);
            if (GetPressedJump()) OnJump?.Invoke();
        }
    }
}
