using UnityEngine;
using UnityEngine.Serialization;

namespace Script.GameScripts
{
    public class InteractableObject : MonoBehaviour
    {
        public bool playerInRange;
        public string itemName = "?_?";

        public string GetItemName()
        {
            return itemName;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.Instance.onTarget)
            {
            
                Debug.Log("item added to inventory");
            
                Destroy(gameObject);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
            }
        }
    }
}
