using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTriggerStay : MonoBehaviour
{
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !source.isPlaying)
        {
            source.PlayOneShot(source.clip);
            Debug.Log("Play On Stay");
        }
    }
}
