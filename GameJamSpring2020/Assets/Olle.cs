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
            navMeshAgent.SetDestination(player.transform.position);
        }
        else
        {
            navMeshAgent.isStopped = true;
        }

    }

    private void Update()
    {
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
