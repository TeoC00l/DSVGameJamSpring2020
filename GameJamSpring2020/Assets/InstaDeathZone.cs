using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDeathZone : MonoBehaviour
{
    DeathHandler deathHandler;
    Vision vision;

    // Start is called before the first frame update
    void Start()
    {
        deathHandler = GameObject.FindObjectOfType<DeathHandler>();
        vision = FindObjectOfType<Vision>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && vision.ScanForOlle())
        {
            deathHandler.die();
        }
    }

}
