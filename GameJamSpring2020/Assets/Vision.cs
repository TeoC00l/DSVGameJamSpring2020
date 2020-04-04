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


        if (seeingOlle){
            float distance = Vector3.Distance(gameObject.transform.position, olle.transform.position);

            if(distance > 40f)
            {
                staticEffect.alpha = 0.005f;
            }else if (distance > 30f)
            {
                staticEffect.alpha = 0.01f;
            }
             else if (distance > 20f)
            {
            staticEffect.alpha = 0.025f;
            }
            else
            {
                staticEffect.alpha = 0.05f;
            }


            staticEffect.alpha = 0.05f;
            Debug.Log("Scare!");
            deathHandler.scare(distance);
        }
        else
        {
            staticEffect.alpha = 0;
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
