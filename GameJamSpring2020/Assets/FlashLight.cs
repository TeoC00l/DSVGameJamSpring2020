using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private AudioClip turnOnAndOffSFX;
    [SerializeField] private AudioClip noBatterySFX;
    public float battery = 100;
    private Light flashLight;
    private bool active = false;
    private float batteryDrain = 7.5f;
    private float batteryRecharge = 5f;

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
                    AudioManager.instance.PlayClip(turnOnAndOffSFX, false, 0.1f);
                }
                else
                {
                    active = false;
                    flashLight.enabled = false;
                    AudioManager.instance.PlayClip(turnOnAndOffSFX, false, 0.1f);

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
                AudioManager.instance.PlayClip(noBatterySFX, false, 0.1f);
                battery = 0;
                Debug.Log("no battery");

            }
        }
        else if(!active && battery <= 100)
        {
            battery += batteryRecharge * Time.deltaTime;
            Debug.Log("battery" + battery);

        }
        Inventory.instance.UpdateBatterySlider(battery);
    }
}
