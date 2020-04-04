using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTriggerStay : MonoBehaviour
{
    AudioSource source;
   [SerializeField] Light[] lights;
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
            StartCoroutine(flickeringLight());
            Debug.Log("Play On Stay");

        }
    }


    private IEnumerator flickeringLight()
    {
        for (int i = 0; i < 3; i++)
        {
            foreach (Light light in lights)
            {
                light.enabled = true;
                yield return new WaitForSeconds(0.25f);
            }
            foreach (Light light in lights)
            {
                light.enabled = false;
                yield return new WaitForSeconds(0.25f);
            }
        }
        
    }
}
