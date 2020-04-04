using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
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
            if (distance > 40f)
            {
                fearCounter += 1;
            }
            else if (distance > 30f)
            {
                fearCounter += 2;
            }
            else if (distance > 20f)
            {
                fearCounter += 4;
            }
            else
            {
                fearCounter += 10;
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
        gameObject.transform.LookAt(olle.transform.position);
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
