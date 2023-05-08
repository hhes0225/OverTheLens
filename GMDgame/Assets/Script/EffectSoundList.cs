using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSoundList : MonoBehaviour
{
    public List<AudioClip> effectSounds;
    public static EffectSoundList instance;

    private void Start()
    {
        instance = this;
    }

    public void playEffectSound(int i)
    {
        MusicManager.instance.SFXPlay("effectSound", effectSounds[i]);
    }

    
}
