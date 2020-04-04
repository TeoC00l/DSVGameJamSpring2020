using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float xAxis;
    float zAxis;
    Rigidbody rBody;
    int speed = 10;
    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        zAxis = Input.GetAxis("Vertical");

        Vector3 move = transform.right * xAxis + transform.forward * zAxis;
        controller.Move(move * speed * Time.deltaTime);



    }
}



//yAxis = Input.GetAxis("Vertical");
//       xAxis = Input.GetAxis("Horizontal");


//        if(yAxis > 0)
//        {
//            rBody.velocity += Vector3.forward* yAxis * speed * Time.deltaTime;
//        }
//        else if(yAxis< 0)
//        {
//            rBody.velocity += Vector3.forward* yAxis * speed * Time.deltaTime;
//        }

//        if (xAxis > 0)
//        {
//            rBody.velocity += Vector3.right* xAxis * speed * Time.deltaTime;
//        }
//        else if (xAxis< 0)
//        {
//            rBody.velocity += Vector3.left* xAxis * speed * Time.deltaTime;
//        }
