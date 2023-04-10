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

    // Start is called before the first frame update
    void Start()
    {
        okButton.onClick.AddListener((okButtonEvent));
        resumeButton.onClick.AddListener((resumeButtonEvent));
        quitButton.onClick.AddListener((quitButtonEvent));


    }

    void okButtonEvent()
    {
        Time.timeScale = 1;
        settingWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void resumeButtonEvent()
    {
        Time.timeScale = 1;
        homeWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
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
}
