using UnityEngine;

namespace Script.GameScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        public CharacterController controller;
 
        public float speed = 12f;
        public float gravity = -9.81f * 2;
        public float jumpHeight = 3f;
 
        public Transform groundCheck;
        public float groundDistance = 0.4f;
        public LayerMask groundMask;

        private Vector3 _velocity;
 
        private bool _isGrounded;
 
        // Update is called once per frame
        private void Update()
        {
            //checking if we hit the ground to reset our falling velocity, otherwise we will fall faster the next time
            _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
 
            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }
 
            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
 
            //right is the red Axis, forward is the blue axis
            var transform1 = transform;
            var move = transform1.right * x + transform1.forward * z;
 
            controller.Move(move * (speed * Time.deltaTime));
 
            //check if the player is on the ground so he can jump
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                //the equation for jumping
                _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
 
            _velocity.y += gravity * Time.deltaTime;
 
            controller.Move(_velocity * Time.deltaTime);
        }
    }
}