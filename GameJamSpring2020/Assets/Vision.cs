using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    DeathHandler deathHandler;
    private bool seeingOlle;
    [SerializeField]private Olle olle;

    // Start is called before the first frame update
    void Start()
    {
        deathHandler = GetComponentInParent<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (seeingOlle){
            deathHandler.scare();
            Debug.Log("Olle seen");
        }
        else
        {
            deathHandler.calm();
            Debug.Log("No olle");

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            seeingOlle = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            seeingOlle = false;
        }
    }

    public bool isSeeingOlle()
    {
        return seeingOlle;
    }

}
