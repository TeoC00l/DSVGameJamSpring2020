using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    DeathHandler deathHandler;
    public bool seeingOlle;
    [SerializeField]private Olle olle;
    public LayerMask visionMask;
    CanvasGroup staticEffect;
    public Vector3 enemyDirection;

    // Start is called before the first frame update
    void Start()
    {


        staticEffect = GameObject.Find("StaticEffect").GetComponent<CanvasGroup>();

        deathHandler = GetComponentInParent<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {


        if (deathHandler == null)
        {
            deathHandler = GetComponentInParent<DeathHandler>();
        }

        float distance = Vector3.Distance(gameObject.transform.parent.transform.position, olle.transform.position);
        Debug.Log(distance);

        if (distance > 40f)
        {
            staticEffect.alpha = 0.00f;
        }
        else if (distance > 30f)
        {
            staticEffect.alpha = 0.00f;
        }
        else if (distance > 20f)
        {
            staticEffect.alpha = 0.01f;
        }
        else if (distance > 15f)
        {
            staticEffect.alpha = 0.02f;
        }
        else if (distance > 10f)
        {
            staticEffect.alpha = 0.03f;

        }
        else if (distance > 5f)
        {
            staticEffect.alpha = 0.04f;
        }
        else
        {
            staticEffect.alpha = 0.5f;
        }



        if (seeingOlle)
        {
            deathHandler.scare(distance);

            if (distance > 40f)
            {
                staticEffect.alpha = 0.005f;
            }
            else if (distance > 30f)
            {
                staticEffect.alpha = 0.01f;
            }
            else if (distance > 20f)
            {
                staticEffect.alpha = 0.04f;
            }
            else if (distance > 10f)
            {
                staticEffect.alpha = 0.07f;
            }
            else if (distance > 5f)
            {
                staticEffect.alpha = 0.09f;
            }
            else
            {
                staticEffect.alpha = 0.12f;
            }
        }else
        {
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

        enemyDirection = olle.transform.position - gameObject.transform.parent.position;
        Physics.Raycast(transform.parent.position, enemyDirection.normalized, out hit, Mathf.Infinity, visionMask);

        Debug.DrawRay(transform.parent.position, enemyDirection, Color.red);

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
