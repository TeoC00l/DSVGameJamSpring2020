using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    GameObject DeathScreen;
    private int fearCounter;
    private int fearThreshold = 1000;
    

    // Start is called before the first frame update
    void Start()
    {
        DeathScreen = GameObject.Find("DeathScreen");
        DeathScreen.SetActive(false);
        fearCounter = 0;
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
        DeathScreen.SetActive(true);
    }
}
