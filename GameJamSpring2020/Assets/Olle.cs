using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olle : MonoBehaviour
{
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject player;
    private bool pursuing;


    // Start is called before the first frame update
    void Start()
    {
        pursuing = true;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pursuing)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(player.transform.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }

    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distance > 20f)
        {
            navMeshAgent.speed = 2f;
        }
        else if (distance > 10f)
        {
            navMeshAgent.speed = 2.5f;
        }
        else if (distance > 5f)
        {
            navMeshAgent.speed = 3f;
        }
        else if (distance > 2f)
        {
            navMeshAgent.speed = 8f;

        }

        if (player.GetComponentInChildren<Vision>().isSeeingOlle())
        {
            pursuing = false;
        }
        else
        {
            pursuing = true;
        }
    }
}
