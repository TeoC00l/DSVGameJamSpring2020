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
        if (fearCounter > fearThreshold)
        {
            die();
        }
        
    }

    public void scare()
    {
        fearCounter+=10;
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
        gameObject.GetComponent<FirstPersonController>().enabled = false;
        gameObject.transform.LookAt(olle.transform.position);
        Time.timeScale = 0;
        DeathScreen.SetActive(true);
    }
}
