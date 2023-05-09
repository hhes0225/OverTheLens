using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Inventory
{
    public class QuickSlotSystem : MonoBehaviour
    {
        public static QuickSlotSystem Instance { get; set; }
 
        // -- UI -- //
        public GameObject quickSlotsPanel;
 
        public List<GameObject> quickSlotsList = new List<GameObject>() { null, null, null, null, null };

        public int selectedSlot = -1;
        public GameObject selectedItem;
   
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
 
 
        private void Start()
        {
            PopulateSlotList();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SelectQuickSlot(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SelectQuickSlot(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SelectQuickSlot(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SelectQuickSlot(4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                SelectQuickSlot(5);
            }
        }

        void SelectQuickSlot(int slot)
        {
           
            if (CheckIfSlotIsFull(slot))
            {
                if (selectedSlot != slot)
                {
                    Debug.Log((selectedSlot != slot) + ": result");
                    selectedSlot = slot;

                    // Unselect previous item
                    if (selectedItem != null)
                    {
                        selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
                    }
                   

                    selectedItem = GetSelectedItem(slot);
                    selectedItem.GetComponent<InventoryItem>().isSelected = true;
                    Debug.Log("item consumed");
                    selectedItem.GetComponent<InventoryItem>().ConsumeItem();
                    selectedItem.GetComponent<InventoryItem>().DestroyThumbnail();
                }
                else    // If we click on the same slot
                {
                    selectedSlot = -1; // null

                    // Unselect previous item
                    if (selectedItem != null)
                    {
                        selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
                        selectedItem = null;
                    }
                }
            }
        }

        

        GameObject GetSelectedItem(int slot)
        {
            return quickSlotsList[slot-1].transform.GetChild(0).gameObject;
        }

        private bool CheckIfSlotIsFull(int slot)
        {
            if (quickSlotsList[slot-1].transform.childCount > 0)
            {
                return true;
            }
            return false;
        }

        private void PopulateSlotList()
        {
            foreach (Transform child in quickSlotsPanel.transform)
            {
                if (child.CompareTag("QuickSlot"))
                {
                    quickSlotsList.Add(child.gameObject);
                }
            }
        }
 
        private GameObject FindNextEmptySlot()
        {
            foreach (GameObject slot in quickSlotsList)
            {
                if (slot.transform.childCount == 0)
                {
                    return slot;
                }
            }
            return new GameObject();
        }
 
        public bool CheckIfFull()
        {
 
            int counter = 0;
 
            foreach (GameObject slot in quickSlotsList)
            {
                if (slot.transform.childCount > 0)
                {
                    counter += 1;
                }
            }
 
            if (counter == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddToQuickSlot(GameObject o)
        {
            // find next free slot
            GameObject availableSlot = FindNextEmptySlot();
            // set transform of our object
            o.transform.SetParent(availableSlot.transform, false);
            // getting clean name
            string cleanName = o.name.Replace("(Clone)", "");

            InventorySystem.Instance.ReCalculateList();
        }
    }

    //void SelectQuickSlot(int slot)
    //{
    //    Debug.Log("Äü½½·Ô function called");
    //    if (CheckIfSlotIsFull(slot))
    //    {
    //        if (selectedSlot != slot)
    //        {
    //            Debug.Log((selectedSlot != slot) + ": result");
    //            selectedSlot = slot;

    //            // Unselect previous item
    //            if (selectedItem != null)
    //            {
    //                selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
    //            }

    //            selectedItem = GetSelectedItem(slot);
    //            selectedItem.GetComponent<InventoryItem>().isSelected = true;
    //        }
    //        else    // If we click on the same slot
    //        {
    //            selectedSlot = -1; // null

    //            // Unselect previous item
    //            if (selectedItem != null)
    //            {
    //                selectedItem.gameObject.GetComponent<InventoryItem>().isSelected = false;
    //                selectedItem = null;
    //            }
    //        }
    //    }
    //}
}