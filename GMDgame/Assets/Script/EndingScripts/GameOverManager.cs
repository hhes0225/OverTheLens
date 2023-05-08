using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private Button goTitleButton;

    [SerializeField]
    private GameObject fadeEffectPanel;

    private void Awake()
    {
        fadeEffectPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener((restartButtonEvent));
        goTitleButton.onClick.AddListener((goTitleButtonEvent));

    }

    void goTitleButtonEvent()
    {
        Debug.Log("gotitle Clicked");
        fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
        Invoke("titleSceneLoader", 1f);
    }

    void restartButtonEvent()
    {
        Debug.Log("restart Clicked");
        fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
        Invoke("gameSceneLoader", 1f);
    }

    void titleSceneLoader()
    {
        SceneManager.LoadScene(0);
    }
    void gameSceneLoader()
    {
        SceneManager.LoadScene(2);
    }

}
