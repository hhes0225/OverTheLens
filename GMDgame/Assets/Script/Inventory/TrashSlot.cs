using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Inventory
{
    public class TrashSlot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Sprite trashClosed;
        public Sprite trashOpened;
 
        private Image _imageComponent;

        private static GameObject DraggedItem => DragDrop.ItemBeingDragged;

        private GameObject _itemToBeDeleted;

        public string ItemName
        {
            get
            {
                var name = _itemToBeDeleted.name;
                const string toRemove = "(Clone)";
                var result = name.Replace(toRemove, "");
                return result;
            }
        }


        private void Start()
        {
            _imageComponent = transform.Find("Background").GetComponent<Image>();
            
        }
 
 
        public void OnDrop(PointerEventData eventData)
        {
            //itemToBeDeleted = DragDrop.itemBeingDragged.gameObject;
            if (DraggedItem.GetComponent<InventoryItem>().isTrashable == true)
            {
                _itemToBeDeleted = DraggedItem.gameObject;
                DeleteItem();
            }
            Debug.Log("OnDrop");
        }

        private void DeleteItem()
        {
            _imageComponent.sprite = trashClosed;
            DestroyImmediate(_itemToBeDeleted.gameObject);
            GameObject.Find("InventorySystem").GetComponent<InventorySystem>().ReCalculateList();
        }
 
        public void OnPointerEnter(PointerEventData eventData)
        {
 
            if (DraggedItem != null && DraggedItem.GetComponent<InventoryItem>().isTrashable == true)
            {
                _imageComponent.sprite = trashOpened;
            }
            
            Debug.Log("OnPointerEnter");
       
        }
 
        public void OnPointerExit(PointerEventData eventData)
        {
            if (DraggedItem != null && DraggedItem.GetComponent<InventoryItem>().isTrashable == true)
            {
                _imageComponent.sprite = trashClosed;
            }
            
            Debug.Log("OnPointerExit");
        }
 
    }
}
