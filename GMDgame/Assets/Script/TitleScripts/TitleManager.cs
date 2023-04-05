using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button exitButton;

    [SerializeField]
    private Button settingButton;

    [SerializeField]
    private GameObject settingWindow;

    private void Awake()
    {
        settingWindow.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener((startButtonEvent));
        exitButton.onClick.AddListener((exitButtonEvent));
        settingButton.onClick.AddListener((settingButtonEvent));
    }

    void startButtonEvent()
    {
        SceneManager.LoadScene(1);
    }

    void exitButtonEvent()
    {
        Application.Quit();
    }

    void settingButtonEvent()
    {
        settingWindow.SetActive(true);
    }


}
