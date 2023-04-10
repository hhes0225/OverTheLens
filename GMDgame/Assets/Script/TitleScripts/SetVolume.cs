using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    void Start()
    {
        //initiate volume value
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    //This function will be automatically called when player change volume
    public void SetLevel(float sliderValue)
    {
        //float sound 
        mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    
}
