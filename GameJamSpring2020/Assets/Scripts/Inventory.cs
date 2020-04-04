using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static int noOfCollectibles = 8;
    public int CollectedRolls = 0;

    public static Inventory instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(CollectedRolls >= noOfCollectibles)
        {
            //do win condition
        }
    }
}
