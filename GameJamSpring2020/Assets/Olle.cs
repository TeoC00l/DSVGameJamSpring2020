using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olle : MonoBehaviour
{
    [HideInInspector] public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public GameObject player;
    private bool pursuing;
    public Transform[] StartPositions;
    public AudioClip KommerOchTarDig;
    private float coolDown;
    public Animator AnimatorController;
    public AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        pursuing = true;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        Vector3 startPos = StartPositions[Random.Range(0, StartPositions.Length - 1)].position;
        navMeshAgent.Warp(startPos);
        Debug.Log("David starting from: " + startPos);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pursuing)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.SetDestination(player.transform.position);
            AnimatorController.SetBool("isRunning", true);
        }
        else
        {
            navMeshAgent.isStopped = true;
            AnimatorController.SetBool("isRunning", false);
        }

    }

    private void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

          if(distance > 60f)
        {
            navMeshAgent.speed = 7.5f;
        }
        else if (distance > 20f)
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
            if (coolDown <= 0)
            {
                Source.PlayOneShot(KommerOchTarDig);
                coolDown = 10000f;
            }
        }
        else if (distance > 2f)
        {
            navMeshAgent.speed = 8f;
        }

        if(coolDown > 0)
        {
            coolDown--;
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
