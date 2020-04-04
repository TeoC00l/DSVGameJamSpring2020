using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    private static int noOfCollectibles = 8;
    public int CollectedRolls = 0;
    public Text TotalRollsText;
    public Text CurrentRollsText;
    public GameObject WinScreen;
    public GameObject DeathScreen;
    public GameObject InGameUI;
    public Slider BatterySlider;
    public GameObject NotePaper;

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
            DoWin();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(NotePaper.activeSelf == false)
            {
                NotePaper.SetActive(true);
            } else if (NotePaper.activeSelf == true)
            {
                NotePaper.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void UpdateRolls()
    {
        CurrentRollsText.text = CollectedRolls.ToString();
    }

    public void DoWin()
    {
        InGameUI.SetActive(false);
        WinScreen.SetActive(true);
    }

    public void DoDeath()
    {
        InGameUI.SetActive(false);
        DeathScreen.SetActive(true);
    }

    public void UpdateBatterySlider(float value)
    {
        BatterySlider.value = value;
    }
}
