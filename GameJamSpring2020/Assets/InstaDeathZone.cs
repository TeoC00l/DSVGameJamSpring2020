using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaDeathZone : MonoBehaviour
{
    DeathHandler deathHandler;

    // Start is called before the first frame update
    void Start()
    {
        deathHandler = GameObject.FindObjectOfType<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            deathHandler.die();
        }
    }

}
