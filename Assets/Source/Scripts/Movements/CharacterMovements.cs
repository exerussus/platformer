using System;
using Source.Scripts.Character;
using UnityEngine;
using UnityEngine.Serialization;

namespace Source.Scripts.Movements
{
    public class CharacterMovements : Movements
    {
        [SerializeField] private Rigidbody2D characterRigidbody2D;
        [SerializeField] private float speed;
        [SerializeField] private float jumpForce;
        [SerializeField] private bool isRightDirection;
        [SerializeField] private float maxVelocity;
        [SerializeField] private JumpColliderListener jumpColliderListener;

        public Action<Vector2, float> OnMove;
        public Action OnJump;

        protected override void Move(float verticalAxis, float horizontalAxis, bool isSpeedModOn)
        {
            if (horizontalAxis > 0 && !isRightDirection)
            {
                characterRigidbody2D.velocity = new Vector2(0, characterRigidbody2D.velocity.y);
                isRightDirection = true;
            }
            else if (horizontalAxis < 0 && isRightDirection)
            {
                characterRigidbody2D.velocity = new Vector2(0, characterRigidbody2D.velocity.y);
                isRightDirection = false;
            }
            else if (horizontalAxis == 0) characterRigidbody2D.velocity = new Vector2(0, characterRigidbody2D.velocity.y);
            if (Mathf.Abs(characterRigidbody2D.velocity.x) < maxVelocity) characterRigidbody2D.AddForce(new Vector2(horizontalAxis * speed, 0f));
            OnMove?.Invoke(characterRigidbody2D.velocity, horizontalAxis);
        }

        protected override void Jump()
        {
            if (jumpColliderListener.IsOnGround)
            {
                characterRigidbody2D.AddForce(new Vector2(0f, jumpForce));
                OnJump?.Invoke();
            }
        }
    }
}