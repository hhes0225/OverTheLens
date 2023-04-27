using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class SelectionManager : MonoBehaviour
    {
 
        public GameObject interactionInfoUI;
        TextMeshProUGUI _interactionText;
 
        private void Start()
        {
            _interactionText = interactionInfoUI.GetComponent<TextMeshProUGUI>();
        }
 
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        // A ray is an infinite line starting at origin and going in some direction.
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))      // to know if it's hits something
            {
                var selectionTransform = hit.transform;
                if (selectionTransform.GetComponent<InteractableObject>())
                {
                    Debug.Log("boucle");
                    _interactionText.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();        //change text to the name of the interactable object
                    _interactionText.text = "tree";
                    interactionInfoUI.SetActive(true);      // the text is visible
                }
                else 
                { 
                    //interactionInfoUI.SetActive(false);     // the text is invisible
                    _interactionText.text = "elsze";
                    interactionInfoUI.SetActive(true); 
                    Debug.Log("else");
                }
            }
            else
            {
                interactionInfoUI.SetActive(false);
            }
        }
    }
}