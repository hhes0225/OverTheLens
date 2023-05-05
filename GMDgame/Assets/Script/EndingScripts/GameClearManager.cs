using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearManager: MonoBehaviour
{
    [SerializeField]
    private Image cutSceneImage;

    [SerializeField]
    private GameObject fadeEffectPanel;

    [SerializeField]
    private Button nextButton;

    int i;
    private string[] imagePath = { "Intro/cut1", "Intro/cut2", "Intro/cut3", "Intro/cut4", "Intro/cut5", "Intro/cut6", "Intro/cut7", "Intro/cut8", "Intro/cut9" };

    [SerializeField]
    private Button restartButton;

    [SerializeField]
    private Button goTitleButton;


    private void Awake()
    {
        fadeEffectPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        restartButton.onClick.AddListener((restartButtonEvent));
        goTitleButton.onClick.AddListener((goTitleButtonEvent));
        StartCoroutine(IntroSceneCoroutine());
        i = 1;
        //if player click window, then change next cut
        nextButton.onClick.AddListener((nextCutScene));
    }

    void nextCutScene()
    {
        if (i < imagePath.Length-1)
        {

            fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
            //Debug.Log(imagePath[i]);
            cutSceneImage.sprite = Resources.Load<Sprite>(imagePath[i]) as Sprite;
            i++;
            fadeEffectPanel.GetComponent<TransitionEffect>().FadeIn();
        }
        else
        {
            fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
            cutSceneImage.sprite = Resources.Load<Sprite>(imagePath[imagePath.Length - 1]) as Sprite;
            fadeEffectPanel.GetComponent<TransitionEffect>().FadeIn();
            activationButton();

        }
    }

    IEnumerator IntroSceneCoroutine()
    {
        yield return new WaitForSeconds(1f);
        //fadeout.GetComponent<Transform>().SetSiblingIndex(3);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
            cutSceneImage.sprite = Resources.Load<Sprite>(imagePath[imagePath.Length - 1]) as Sprite;
            fadeEffectPanel.GetComponent<TransitionEffect>().FadeIn();
            activationButton();
        }
    }

    void activationButton()
    {
        restartButton.gameObject.SetActive(true);
        goTitleButton.gameObject.SetActive(true);
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
