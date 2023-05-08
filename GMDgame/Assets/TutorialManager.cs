using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    
    [SerializeField]
    private GameObject fadeEffectPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
            Invoke("nextSceneLoader", 1f);
        }
    }
    
    private void Awake()
    {
        fadeEffectPanel.SetActive(true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener((startButtonEvent));
    }
    
    void startButtonEvent()
    {
        
        fadeEffectPanel.GetComponent<TransitionEffect>().FadeOut();
        Invoke("nextSceneLoader", 1f);
    }
    
    void nextSceneLoader()
    {
        SceneManager.LoadScene(2);
    }
}
