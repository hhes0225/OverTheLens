using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class SelectionManager : MonoBehaviour
    {

        public static SelectionManager Instance
        {
            get;
            set;
        }
        
        public bool onTarget;
        
        
        public GameObject interactionInfoUI;
        TextMeshProUGUI _interactionText;
 
        private void Start()
        {
            _interactionText = interactionInfoUI.GetComponent<TextMeshProUGUI>();
        }

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

        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        // A ray is an infinite line starting at origin and going in some direction.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))      // to know if it's hits something
            {
                var selectionTransform = hit.transform;
                //Debug.Log(hit.transform.name);

                InteractableObject interactable = selectionTransform.GetComponent<InteractableObject>();
                
                if (interactable && interactable.playerInRange)
                {
                    onTarget = true;
                    
                    _interactionText.text = interactable.GetItemName();        //change text to the name of the interactable object
                    interactionInfoUI.SetActive(true);      // the text is visible
                }
                else
                {
                    onTarget = false;
                    interactionInfoUI.SetActive(false);     // the text is invisible
                }
            }
            else
            {
                onTarget = false;
                interactionInfoUI.SetActive(false);
            }
        }
    }
}