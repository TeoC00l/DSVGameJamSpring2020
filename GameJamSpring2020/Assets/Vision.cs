using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    DeathHandler deathHandler;
    private bool seeingOlle;
    [SerializeField]private Olle olle;
    public LayerMask visionMask;

    // Start is called before the first frame update
    void Start()
    {
        deathHandler = GetComponentInParent<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {

        if (seeingOlle){
            Debug.Log("Scare!");
            deathHandler.scare();
        }
        else
        {
            Debug.Log("Calm!");
            deathHandler.calm();

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (ScanForOlle())
            {
                seeingOlle = true;
            }
            else
            {
                seeingOlle = false;
            }
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

    private bool ScanForOlle()
    {
        RaycastHit hit;

        Vector3 direction = olle.transform.position - gameObject.transform.parent.position;
        Physics.Raycast(transform.parent.position, direction.normalized, out hit, Mathf.Infinity, visionMask);

        Debug.DrawRay(transform.parent.position, direction, Color.red);

        if(hit.collider.gameObject.tag == "Enemy")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
