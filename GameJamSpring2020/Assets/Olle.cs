using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olle : MonoBehaviour
{
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
}
