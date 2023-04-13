using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField]
    private Image cutSceneImage;

    [SerializeField]
    private GameObject fadeEffectPanel;

    [SerializeField]
    private Button nextButton;

    int i;
    private string[] imagePath = { "Intro/cut1", "Intro/cut2", "Intro/cut3", "Intro/cut4", "Intro/cut5", "Intro/cut6", "Intro/cut7", "Intro/cut8", "Intro/cut9" };

    private void Awake()
    {
        fadeEffectPanel.SetActive(true);
    }

    void Start()
    {
        StartCoroutine(IntroSceneCoroutine());
        i = 1;
        //if player click window, then change next cut
        nextButton.onClick.AddListener((nextCutScene));
    }

    void nextCutScene()
    {
        if (i < imagePath.Length)
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
            Invoke("nextSceneLoader", 1f);

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
            Invoke("nextSceneLoader", 1f);
        }
    }
    void nextSceneLoader()
    {
        SceneManager.LoadScene(2);
    }
}
