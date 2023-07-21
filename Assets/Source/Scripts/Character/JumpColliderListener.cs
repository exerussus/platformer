
using UnityEngine;

namespace Source.Scripts.Character
{
    public class JumpColliderListener : MonoBehaviour
    {
        [SerializeField] private bool isOnGround;
        public bool IsOnGround => isOnGround;

        private void OnTriggerEnter2D(Collider2D other)
        {
            isOnGround = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isOnGround = false;
        }
    }
}