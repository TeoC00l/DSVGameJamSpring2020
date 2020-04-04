using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Clips;
    public AudioSource MusicSource, FXSource;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayClip(AudioClip clip, bool looping)
    {
        FXSource.PlayOneShot(clip);
        FXSource.loop = looping;
    }

    void PlayMusic(AudioClip clip)
    {
        MusicSource.PlayOneShot(clip);
    }
}
