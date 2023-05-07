using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] musics;
    public AudioMixer mixer;

    public static MusicManager instance;

    //guarantee music object uniqueness
    //this object will not be destroyed after scene change
    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");
        

        if (musics.Length >= 2)
            Destroy(this.gameObject);
        else
        {
            instance = this;
        }

        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(instance);
        //}
        //else
        //{
        //    Destroy(gameObject); 
        //}

        audioSource = GetComponent<AudioSource>();
    }

    //private void Start()
    //{
    //    mixer.SetFloat("MusicVolume", Mathf.Log10(0.3f) * 20);
    //}

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void SFXPlay(string sfxName, AudioClip clip)
    {
        GameObject tmpSFX = new GameObject(sfxName+"Sound");
        AudioSource audioSource = tmpSFX.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();

        Destroy(audioSource, clip.length);
    }
}
