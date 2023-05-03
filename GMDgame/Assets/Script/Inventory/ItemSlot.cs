using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Inventory
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
 
        public GameObject Item
        {
            get
            {
                if (transform.childCount > 0 )
                {
                    return transform.GetChild(0).gameObject;
                }
 
                return null;
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            Debug.Log("OnDrop");
 
            //if there is not item already then set our item.
            if (!Item)
            {
 
                DragDrop.ItemBeingDragged.transform.SetParent(transform);
                DragDrop.ItemBeingDragged.transform.localPosition = new Vector2(0, 0);

                if (transform.CompareTag("QuickSlot") == false)
                {
                    DragDrop.ItemBeingDragged.GetComponent<InventoryItem>().isQuickSlotted = false;
                }

                if (transform.CompareTag("QuickSlot"))
                {
                    DragDrop.ItemBeingDragged.GetComponent<InventoryItem>().isQuickSlotted = true;
                }
            }
 
 
        }
 
 
 
 
    }
}