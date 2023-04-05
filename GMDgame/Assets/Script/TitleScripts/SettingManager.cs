using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField]
    private Button okButton;

    [SerializeField]
    private GameObject settingWindow;

    // Start is called before the first frame update
    void Start()
    {
        okButton.onClick.AddListener((okButtonEvent));
    }


    void okButtonEvent()
    {
        settingWindow.SetActive(false);
    }


    
}
