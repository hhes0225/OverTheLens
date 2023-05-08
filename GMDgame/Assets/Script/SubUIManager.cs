using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubUIManager : MonoBehaviour
{
    [SerializeField]
    private Button okButton;

    [SerializeField]
    private GameObject settingWindow;

    [SerializeField]
    private GameObject homeWindow;

    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private GameObject fadeEffectPanel;

    [SerializeField]
    private GameObject toggleAWSD;

    [SerializeField]
    private GameObject toggleZQSD;

    public static SubUIManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        okButton.onClick.AddListener((okButtonEvent));
        resumeButton.onClick.AddListener((resumeButtonEvent));
        quitButton.onClick.AddListener((quitButtonEvent));
        toggleAWSD.GetComponent<Toggle>().onValueChanged.AddListener((toggleAWSDEvent));
        toggleZQSD.GetComponent<Toggle>().onValueChanged.AddListener((toggleZQSDEvent));

    }

    void okButtonEvent()
    {
        Time.timeScale = 1;
        settingWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        UIMananger.instance.uiClick = false;
    }

    void resumeButtonEvent()
    {
        Time.timeScale = 1;
        homeWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        UIMananger.instance.uiClick = false;
    }

    void quitButtonEvent()
    {
        Time.timeScale = 1;
        fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
        Invoke("titleSceneLoader", 1f);
    }

    void titleSceneLoader()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOverEvent()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
        Invoke("gameOverSceneLoader", 1f);
    }

    public void GameClearEvent()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
        Invoke("gameClearSceneLoader", 1f);
    }

    void gameOverSceneLoader()
    {
        SceneManager.LoadScene(3);
    }

    void gameClearSceneLoader()
    {
        SceneManager.LoadScene(4);
    }

    void toggleAWSDEvent(bool isOn)
    {
        if (isOn)
        {
            toggleZQSD.GetComponent<Toggle>().isOn = false;
            toggleAWSD.GetComponent<Toggle>().isOn = true;
        }
    }

    void toggleZQSDEvent(bool isOn)
    {
        if (isOn)
        {
            toggleAWSD.GetComponent<Toggle>().isOn = false;
            toggleZQSD.GetComponent<Toggle>().isOn = true;
        }
    }
}