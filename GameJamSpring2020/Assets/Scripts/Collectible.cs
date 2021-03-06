﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public AudioClip PickupClip;
    private bool picked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !picked)
        {
            picked = true;
            Debug.Log("Picking up toilet roll");
            AudioManager.instance.PlayClip(PickupClip, false, 0.1f);
            Inventory.instance.CollectedRolls++;
            Inventory.instance.UpdateRolls(gameObject.name);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
