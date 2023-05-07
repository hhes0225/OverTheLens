using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    [SerializeField]
    HPbarController buttonActionGauge;

    [SerializeField]
    int maxValue;

    bool isX = true;

    private void Start()
    {
        //buttonActionGauge = this.GetComponent<HPbarController>();
        buttonActionGauge.Initalize(0f, maxValue);

    }

    private void Update()
    {
        if (isX) { 
            if (Input.GetKeyDown(KeyCode.X))
            {
                GaugeFilled(2);
                isX = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                GaugeFilled(2);
                isX = true;
            }
        }

        if (buttonActionGauge.currentValue == maxValue)
        {
            this.gameObject.SetActive(false);
            buttonActionGauge.Initalize(0f, maxValue);
            isX = true;
        }
    }

    public void GaugeFilled(int filled)
    {
        Debug.Log("Gauge Filled");
        buttonActionGauge.thisCurrentValue += filled;
    }
}
