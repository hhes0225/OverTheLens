using UnityEngine;

namespace Script
{
    public class MouseMovement : MonoBehaviour
    {
 
        public float mouseSensitivity = 300f;   // public for changing it in the inspector
 
        // control the rotation around the x and the y axes
        private float _xRotation;   // red axes : look down / up
        private float _yRotation;   // green axes : look right / left

        private void Start()
        {
            // Locking the cursor to the middle of the screen and making it invisible
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
 
            // control rotation around x axis (Look up and down)
            _xRotation -= mouseY;
 
            // we clamp the rotation so we can't Over-rotate (like in real life)
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
 
            // control rotation around y axis (Look up and down)
            _yRotation += mouseX;
 
            // applying both rotations
            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
 
        }
    }
}