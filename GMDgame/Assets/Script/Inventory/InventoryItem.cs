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

        // --- Approach to Glasses Event --- //
        TimerGlassesEventController eventTimer;
        GlassesEventTrigger glassesTrigger;
        
        
        // --- Quick Slot --- //
        public bool isQuickSlottable;
        private GameObject _quickSlot;
        public bool isQuickSlotted;

        public bool isSelected;
        
        private void Start()
        {
            eventTimer = GameObject.Find("TimerGlassesEventSlider").GetComponent<TimerGlassesEventController>();
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
            if (!this.transform.parent.name.Contains("Quick") && !this.transform.tag.Contains("Equip"))
            {
                //Left Mouse Button Click on
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    ConsumeItem();
                }
                //Right Mouse Button Click on
                if (eventData.button == PointerEventData.InputButton.Right)
                {
                    if (isQuickSlottable && isQuickSlotted == false && QuickSlotSystem.Instance.CheckIfFull() == false)
                    {
                        QuickSlotSystem.Instance.AddToQuickSlot(gameObject);
                        isQuickSlotted = true;
                    }
                }
            }
            else
            {
                Debug.Log(this.transform.parent.name + ": item is in quick slot");
                
            }
        }
 
        // Triggered when the mouse button is released over the item that has this script.
        public void OnPointerUp(PointerEventData eventData)
        {
            if (!this.transform.parent.name.Contains("Quick") && !this.transform.tag.Contains("Equip"))
            {
                if (eventData.button == PointerEventData.InputButton.Left)
                {
                    if (isConsumable && _itemPendingConsumption == gameObject)
                    {
                        DestroyImmediate(gameObject);
                        //InventorySystem.Instance.ReCalculeList();
                    }
                }
            }
        }

        public void ConsumeItem()
        {
            EffectSoundList.instance.playEffectSound(0);
            if (isConsumable)
            {
                switch (this.transform.tag)
                {
                    //Consume Food
                    case "Food": ConsumeFood(); break;
                    //Consume Liquor
                    case "Liquor": ConsumeFood(); ConsumeLiquor(); break;
                    //Consume Potion
                    case "Potion":
                        if (eventTimer.timerSlider.value < eventTimer.timerSlider.maxValue)
                        {
                            Debug.Log("Potion");
                            if (this.transform.name.Contains("green"))
                            {
                                
                                ConsumeGreenPotion(healthEffect);
                                
                            }
                            else
                            {
                                ConsumeBrownPotion(healthEffect);
                            }
                        }
                        break;
                    default: break;
                }
            }

            
        }

        public void DestroyThumbnail()
        {
            if (_itemPendingConsumption == gameObject)
            {
                Destroy(gameObject);
            }
        }

        

        public void ConsumeFood()
        {
            // Setting this specific gameobject to be the item we want to destroy later
            _itemPendingConsumption = gameObject;
            ConsumingFunction(healthEffect);
        }

        public void ConsumeGreenPotion(float second)
        {
            
            int lucky;
            lucky = Random.Range(0, 2);//get 0 or 1

            // Setting this specific gameobject to be the item we want to destroy later
            _itemPendingConsumption = gameObject;
            _itemInfoUI.SetActive(false);

            if (lucky == 0)//lucky is 0, glasses event gauge will increase
            {
                eventTimer.timerSlider.value += second;
                Debug.Log(second + " second increase");
         
            }
            else//lucky is 1, glasses event gauge will decrease
            {
                eventTimer.timerSlider.value -= second;
                Debug.Log(second + " second decrease");
                EffectSoundList.instance.playEffectSound(1);
            }


        }

        public void ConsumeBrownPotion(float percent)
        {
            
            int lucky;
            lucky = Random.Range(0, 100);

            // Setting this specific gameobject to be the item we want to destroy later
            _itemPendingConsumption = gameObject;
            _itemInfoUI.SetActive(false);

            if (lucky <= percent)//lucky is smaller than percent, it prevent glasses event for 1 time.
            {
                eventTimer.preventEvent = true;
                Debug.Log(percent + "% of prevent");
                EffectSoundList.instance.playEffectSound(1);
            }
            else//lucky is bigger than percent, it triggers glasses event instantly.
            {
                eventTimer.timerSlider.value = eventTimer.timerSlider.maxValue - 0.3f;
                Debug.Log((100-percent) + "% of triggering instantly");
            }

        }

        public void ConsumeLiquor()
        {
            //Drunk
            eventTimer.timerSlider.value = eventTimer.timerSlider.maxValue - 0.3f;
            eventTimer.isDrunk = true;

        }

        public void ConsumeEquip()
        {
            if (isConsumable)
            {
               // Setting this specific gameobject to be the item we want to destroy later
                _itemPendingConsumption = gameObject;
                
                if (_itemPendingConsumption == gameObject)
                {
                    Destroy(gameObject);
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
                    GameObject.Find("Player").GetComponent<Player>().setHealth(maxHealth);
                }
                else
                {
                    GameObject.Find("Player").GetComponent<Player>().PlayerRecovered((int)healthEffect);
                }
            }
        }
    }
}