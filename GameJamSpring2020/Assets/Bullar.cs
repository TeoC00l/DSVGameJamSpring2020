using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullar : MonoBehaviour
{
    public GameObject Player;
    private DeathHandler deathHandler;

    public void Start()
    {
        deathHandler = Player.GetComponent<DeathHandler>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            deathHandler.dieBullarEdition();
        }
    }
}
