using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private int fearCounter;
    private int fearThreshold = 1000;
    

    // Start is called before the first frame update
    void Start()
    {
        fearCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (fearCounter > fearThreshold)
        {
            Debug.Log("u are dead");
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
}
