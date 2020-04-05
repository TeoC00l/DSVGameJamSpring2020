using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Clips;
    public AudioSource MusicSource, FXSource, StaticSource;
    public static AudioManager instance;

    void Start()
    {
        if (instance)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        StaticSource.Stop();
    }


    public void PlayClip(AudioClip clip, bool looping, float volume)
    {
        FXSource.volume = volume;
        FXSource.PlayOneShot(clip);
        FXSource.loop = looping;
    }

   public void PlayMusic(AudioClip clip)
    {
        MusicSource.PlayOneShot(clip);
    }
}
