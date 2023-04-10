using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMananger : MonoBehaviour
{

    [SerializeField]
    private Button settingButton;

    [SerializeField]
    private GameObject settingWindow;

    [SerializeField]
    private Button homeButton;

    [SerializeField]
    private GameObject homeWindow;

    private void Awake()
    {
        //To apply the volume setting
        settingWindow.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("settingWindowOff", 0.01f);
        homeWindow.SetActive(false);

        //Add button listeners(setting button, home button)
        settingButton.onClick.AddListener((settingButtonEvent));
        homeButton.onClick.AddListener((homeButtonEvent));
    }


    void settingButtonEvent()
    {
        settingWindow.SetActive(true);
    }

    void homeButtonEvent()
    {
        homeWindow.SetActive(true);
    }

    void settingWindowOff()
    {
        settingWindow.SetActive(false);
    }
}
