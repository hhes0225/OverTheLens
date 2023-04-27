using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarController : MonoBehaviour
{
    private Image filledArea;

    [SerializeField]
    private float lerpSpeed;

    private float currentFill;

    public float thisMaxValue { get; set; }

    private float currentValue;

    public float thisCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > thisMaxValue) currentValue = thisMaxValue;
            else if (value < 0) currentValue = 0;
            else currentValue = value;

            currentFill = currentValue / thisMaxValue;
        }
    }

    void Start()
    {
        filledArea = GetComponent<Image>();
    }

    void Update()
    {
        if (currentFill != filledArea.fillAmount)
        {
            filledArea.fillAmount = Mathf.Lerp(filledArea.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Initalize(float currentValue, float maxValue)
    {
        thisMaxValue = maxValue;
        thisCurrentValue = currentValue;
    }
}
