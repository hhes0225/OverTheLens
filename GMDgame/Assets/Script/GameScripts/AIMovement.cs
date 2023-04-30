using UnityEngine;

namespace Script.GameScripts
{
    public class AIMovement : MonoBehaviour
    {
        Animator _animator;
   
        public float moveSpeed = 0.2f;
 
        Vector3 _stopPosition;
 
        float _walkTime;
        public float walkCounter;
        float _waitTime;
        public float waitCounter;
 
        int _walkDirection;
 
        public bool isWalking;
 
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
 
            //So that all the prefabs don't move/stop at the same time
            _walkTime = Random.Range(3,6);
            _waitTime = Random.Range(5,7);
 
 
            waitCounter = _waitTime;
            walkCounter = _walkTime;
 
            ChooseDirection();
        }
 
        // Update is called once per frame
        void Update()
        {
            if (isWalking)
            {
 
                _animator.SetBool("isRunning", true);
 
                walkCounter -= Time.deltaTime;
 
                switch (_walkDirection)
                {
                    case  0:
                        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                        transform.position += transform.forward * (moveSpeed * Time.deltaTime);
                        break;
                    case  1:
                        transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                        transform.position += transform.forward * (moveSpeed * Time.deltaTime);
                        break;
                    case  2:
                        transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                        transform.position += transform.forward * (moveSpeed * Time.deltaTime);
                        break;
                    case  3:
                        transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                        transform.position += transform.forward * (moveSpeed * Time.deltaTime);
                        break;
                }
 
                if (walkCounter <= 0)
                {
                    _stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    isWalking = false;
                    //stop movement
                    transform.position = _stopPosition;
                    _animator.SetBool("isRunning", false);
                    //reset the waitCounter
                    waitCounter = _waitTime;
                }
 
 
            }
            else
            {
 
                waitCounter -= Time.deltaTime;
 
                if (waitCounter <= 0)
                {
                    ChooseDirection();
                }
            }
        }
 
 
        public void ChooseDirection()
        {
            _walkDirection = Random.Range(0, 4);
 
            isWalking = true;
            walkCounter = _walkTime;
        }
    }
}
