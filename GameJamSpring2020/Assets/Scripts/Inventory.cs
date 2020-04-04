using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private static int noOfCollectibles = 8;
    public int CollectedRolls = 0;
    public Text TotalRollsText;
    public Text CurrentRollsText;

    public static Inventory instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        TotalRollsText.text = "/ " + noOfCollectibles;
        CurrentRollsText.text = CollectedRolls.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(CollectedRolls >= noOfCollectibles)
        {
            //do win condition
        }
    }

    public void UpdateRolls()
    {
        CurrentRollsText.text = CollectedRolls.ToString();
    }
}
