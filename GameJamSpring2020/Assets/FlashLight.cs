using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{


    Light flashLight;
    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLight.enabled)
            {
                flashLight.enabled = false;
            }
            else
            {
                flashLight.enabled = true;
            }
        }
    }
}
