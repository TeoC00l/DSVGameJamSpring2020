using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    public float battery = 200;
    private Light flashLight;
    private bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
        flashLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(battery > 5) { 
            
                if (!active)
                {
                    active = true;
                    flashLight.enabled = true;

                }
                else
                {
                    active = false;
                    flashLight.enabled = false;
                }
            }
        }


        if (active)
        {
            battery -= 10 * Time.deltaTime;
            Debug.Log(battery);
            if (battery <= 0)
            {
                active = false;
                flashLight.enabled = false;
                battery = 0;
                Debug.Log("no battery");

            }
        }

    }
}
