using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    public float battery = 200;
    private Light flashLight;
    private bool active = false;
    private float batteryDrain = 10;
    private float batteryRecharge = 5;

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
                    AudioManager.instance.PlayClip(sound, false);
                }
                else
                {
                    active = false;
                    flashLight.enabled = false;
                    AudioManager.instance.PlayClip(sound, false);

                }
            }
        }


        if (active)
        {
            battery -= batteryDrain * Time.deltaTime;
            Debug.Log(battery);
            if (battery <= 0)
            {
                active = false;
                flashLight.enabled = false;
                battery = 0;
                Debug.Log("no battery");

            }
        }
        else
        {
            battery += batteryRecharge * Time.deltaTime;
            Debug.Log("battery" + battery);

        }

    }
}
