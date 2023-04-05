using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    [SerializeField]
    private Button okButton;

    [SerializeField]
    private GameObject settingWindow;

    [SerializeField]
    //private AudioMixer mixer;
    private AudioSource audioSource;
    private GameObject[] musics;


    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if (musics.Length >= 2)
            Destroy(this.gameObject);

        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        okButton.onClick.AddListener((okButtonEvent));
    }


    void okButtonEvent()
    {
        settingWindow.SetActive(false);
    }


    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
