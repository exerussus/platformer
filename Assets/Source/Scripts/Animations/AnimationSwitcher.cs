using Source.Scripts.Character;
using Source.Scripts.Movements;
using UnityEngine;

namespace Source.Scripts.Animations
{
    public class AnimationSwitcher : MonoBehaviour
    {
        [SerializeField] private CharacterMovements characterMovements;
        [SerializeField] private Animator animator;
        [SerializeField] private Transform prefabTransform;
        
        
        private bool isFacingRight = false;

        private void OnEnable()
        {
            characterMovements.OnMove += MoveListener;
            characterMovements.OnJump += JumpListener;
        }


        private void OnDisable()
        {
            characterMovements.OnMove -= MoveListener;
            characterMovements.OnJump -= JumpListener;
        }
        
        
        private void JumpListener()
        {
            animator.SetTrigger("jumping");
        }
        
        private void MoveListener(Vector2 characterVelocity, float horizontalAxis)
        {
            if (characterVelocity.x > 0 && !isFacingRight && horizontalAxis > 0)
            {
                Flip(characterVelocity);
            }
            else if (characterVelocity.x < 0 && isFacingRight && horizontalAxis < 0)
            {
                Flip(characterVelocity);
            }
            animator.SetFloat("velocity", Mathf.Abs(characterVelocity.x));
        }

        private void Flip(Vector2 characterVelocity)
        {
            isFacingRight = !isFacingRight;
            var localScale = prefabTransform.localScale;
            localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
            prefabTransform.localScale = localScale;
            animator.SetBool("isFacingRight", isFacingRight);
        }
    }
}