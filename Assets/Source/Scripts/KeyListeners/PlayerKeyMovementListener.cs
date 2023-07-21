using UnityEngine;

namespace Source.Scripts.KeyListeners
{
    public class PlayerKeyMovementListener : KeyMovementListener
    {
        
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private ButtonListener buttonListener;
        
        protected override float SetAxisV()
        {
            return joystick.Vertical;
        }

        protected override float SetAxisH()
        {
            var horizontalAxis = joystick.Horizontal;
            if (horizontalAxis > 0) horizontalAxis = 1;
            else if (horizontalAxis < 0) horizontalAxis = -1;
            else horizontalAxis = 0;
            
            return horizontalAxis;
        }

        protected override bool SwitchStealthMode()
        {
            return Input.GetKeyDown(KeyCode.C);
        }

        protected override bool GetPressedJump()
        {
            return buttonListener.GetButtonDown();
        }
    }
}