using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    public GameObject davidsFace;
    GameObject DeathScreen;
    private int fearCounter;
    private int fearThreshold = 1000;
    GameObject olle;
    public AudioClip deathClip;
    public AudioClip bullDeathClip;
    public Transform behindPlayerPos;

    private bool isDying = false;

    // Start is called before the first frame update
    void Awake()
    {
        DeathScreen = GameObject.Find("DeathScreen");
        DeathScreen.SetActive(false);
        fearCounter = 0;
    }

    private void Start()
    {
        davidsFace = GameObject.Find("Face");
        olle = GameObject.Find("Olle 1");
    }

    // Update is called once per frame
    void Update()
    {
        if (fearCounter > fearThreshold && !isDying)
        {
            isDying = true;
            die();
        }
        
    }

    public void scare(float distance)
    {
            if (distance > 20f)
            {
                fearCounter += 2;
            }
            else if (distance > 10f)
            {
                fearCounter += 4;
            }
            else if (distance > 5f)
            {
                fearCounter += 8;
            }
            else if (distance > 3f)
            {
                fearCounter += 10;
            }
            else
            {
            fearCounter += 20;
            }
    }   

    public void calm()
    {
        if (fearCounter < 0)
        {
            fearCounter--;
        }
    }

    public void die()
    {
        Debug.Log("Dying");
        AudioManager.instance.PlayClip(deathClip, false);
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        gameObject.transform.Rotate(0f, 0f, 0f, Space.World);
        gameObject.transform.LookAt(davidsFace.transform.position);
        Time.timeScale = 0;
        DeathScreen.SetActive(true);
    }

    public void dieBullarEdition()
    {
        olle.transform.position = behindPlayerPos.position;
        AudioManager.instance.PlayClip(bullDeathClip, false);
        die();
    }
}
