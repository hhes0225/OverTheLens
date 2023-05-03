using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.Inventory
{
    public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        // --- Is this item trashable --- //
        public bool isTrashable;
 
        // --- Item Info UI --- //
        private GameObject _itemInfoUI;
 
        private TextMeshProUGUI _itemInfoUIItemName;
        private TextMeshProUGUI _itemInfoUIItemDescription;
        private TextMeshProUGUI _itemInfoUIItemFunctionality;
 
        public string thisName, thisDescription, thisFunctionality;
 
        // --- Consumption --- //
        private GameObject _itemPendingConsumption;
        public bool isConsumable;

        public float healthEffect;
        
        
        // --- Quick Slot --- //
        public bool isQuickSlottable;
        private GameObject _quickSlot;
        public bool isQuickSlotted;

        public bool isSelected;
        
        private void Start()
        {
            _itemInfoUI = InventorySystem.Instance.ItemInfoUI;
            _itemInfoUIItemName = _itemInfoUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            _itemInfoUIItemDescription = _itemInfoUI.transform.Find("ItemDescription").GetComponent<TextMeshProUGUI>();
            _itemInfoUIItemFunctionality = _itemInfoUI.transform.Find("ItemFunctionality").GetComponent<TextMeshProUGUI>();
        }
        
        void Update()
        {
            if (isSelected)
            {
                gameObject.GetComponent<DragDrop>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<DragDrop>().enabled = true;
            }
        }
 
        // Triggered when the mouse enters into the area of the item that has this script.
        public void OnPointerEnter(PointerEventData eventData)
        {
            _itemInfoUI.SetActive(true);
            _itemInfoUIItemName.text = thisName;
            _itemInfoUIItemDescription.text = thisDescription;
            _itemInfoUIItemFunctionality.text = thisFunctionality;
        }
 
        // Triggered when the mouse exits the area of the item that has this script.
        public void OnPointerExit(PointerEventData eventData)
        {
            _itemInfoUI.SetActive(false);
        }
 
        // Triggered when the mouse is clicked over the item that has this script.
        public void OnPointerDown(PointerEventData eventData)
        {
            //Right Mouse Button Click on
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (isConsumable)
                {
                    // Setting this specific gameobject to be the item we want to destroy later
                    _itemPendingConsumption = gameObject;
                    ConsumingFunction(healthEffect);
                }

                if (isQuickSlottable && isQuickSlotted == false && QuickSlotSystem.Instance.CheckIfFull() == false)
                {
                    QuickSlotSystem.Instance.AddToQuickSlot(gameObject);
                    isQuickSlotted = true;
                }
            }
        }
 
        // Triggered when the mouse button is released over the item that has this script.
        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (isConsumable && _itemPendingConsumption == gameObject)
                {
                    DestroyImmediate(gameObject);
                    //InventorySystem.Instance.ReCalculeList();
                }
            }
        }
 
        private void ConsumingFunction(float health)
        {
            _itemInfoUI.SetActive(false);
 
            HealthEffectCalculation(health);
        }


        private static void HealthEffectCalculation(float healthEffect)
        {
            // --- Health --- //

            float healthBeforeConsumption = GameObject.Find("Player").GetComponent<Player>().hpBar.thisCurrentValue;
            float maxHealth = GameObject.Find("Player").GetComponent<Player>().hpBar.thisMaxValue;

            if (healthEffect != 0)
            {
                if ((healthBeforeConsumption + healthEffect) > maxHealth)
                {
                    GameObject.Find("Player").GetComponent<Player>().hpBar.thisCurrentValue = maxHealth;
                }
                else
                {
                    GameObject.Find("Player").GetComponent<Player>().hpBar.thisCurrentValue += healthEffect;
                }
            }
        }
    }
}