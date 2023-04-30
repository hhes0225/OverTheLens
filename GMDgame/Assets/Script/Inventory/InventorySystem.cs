using System;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

namespace Script.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
 
        public static InventorySystem Instance { get; set; }

        public GameObject inventoryScreenUI;

        public List<GameObject> slotList = new List<GameObject>();

        public List<string> itemsList = new List<string>();

        private GameObject _itemAdd;

        private GameObject _slotEquip;

        public bool isOpen;

        // public bool isFull;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }
 
 
        void Start()
        {
            isOpen = false;

            PopulateSlotList();
        }

        private void PopulateSlotList()
        {
            foreach (Transform child in inventoryScreenUI.transform)
            {
                if (child.CompareTag("Slot"))
                {
                    slotList.Add(child.gameObject);
                }
            }
        }
        
        void Update()
        {
 
            if (Input.GetKeyDown(KeyCode.I) && !isOpen)
            {
 
                Debug.Log("i is pressed");
                inventoryScreenUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                isOpen = true;
 
            }
            else if (Input.GetKeyDown(KeyCode.I) && isOpen)
            {
                inventoryScreenUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isOpen = false;
            }
        }

        public void AddToInv(string ItemName)
        {
            _slotEquip = NextEmptySlot();
            _itemAdd = Instantiate(Resources.Load<GameObject>(ItemName), _slotEquip.transform.position, _slotEquip.transform.rotation);
            _itemAdd.transform.SetParent(_slotEquip.transform);
            _itemAdd.transform.localScale = new Vector3(1f, 1f, 1f);
            
            itemsList.Add(ItemName);
        }

        private GameObject NextEmptySlot()
        {
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount == 0)
                {
                    return slot;
                }
            }

            return new GameObject();
        }

        public bool CheckifFull()
        {
            int counter = 0;
            foreach (GameObject slot in slotList)
            {
                if (slot.transform.childCount > 0)
                {
                    counter += 1;
                }
            }
            if (counter == 20)
            {
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
