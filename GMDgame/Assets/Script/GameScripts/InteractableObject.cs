using Script.Inventory;

using UnityEngine;
using UnityEngine.Serialization;

namespace Script.GameScripts
{
    public class InteractableObject : MonoBehaviour
    {
        public bool playerInRange;
        public string itemName = "?_?";

        public AudioClip pickSound;


        public string GetItemName()
        {
            return itemName;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && playerInRange && SelectionManager.Instance.onTarget)
            {
                MusicManager.instance.SFXPlay("pickSound", pickSound);
                Debug.Log(itemName + " clicked");
                if (itemName != "glasses") { 
                    if (!InventorySystem.Instance.CheckifFull())
                    {
                        InventorySystem.Instance.AddToInv(itemName);
                        Destroy(gameObject);
                    }
                    else
                    {
                        Debug.Log("inventory is full!!!!");
                    }
                }
                else
                {
                    Debug.Log("Clear Game!");
                    SubUIManager.instance.GameClaerEvent();
                }
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
