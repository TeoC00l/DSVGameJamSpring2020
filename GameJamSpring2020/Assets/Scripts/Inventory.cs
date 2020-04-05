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
    public GameObject[] Lines;

    public static Inventory instance;


    private void OnEnable()
    {
        Time.timeScale = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        TotalRollsText.text = "/ " + noOfCollectibles;
        CurrentRollsText.text = CollectedRolls.ToString();
        AudioManager.instance.StaticSource.Play();
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
            AudioManager.instance.StaticSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("SampleScene");
            AudioManager.instance.StaticSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DoWin();
        }

    }

    public void UpdateRolls(string pickedRollName)
    {
        CurrentRollsText.text = CollectedRolls.ToString();
        switch (pickedRollName)
        {
            case "ToarulleKorridorLH":
                Lines[7].SetActive(true);
                break;
            case "ToarulleLH":
                Lines[1].SetActive(true);
                break;
            case "ToarulleSL":
                Lines[0].SetActive(true);
                break;
            case "ToarulleCafe":
                Lines[2].SetActive(true);
                break;
            case "ToarulleEntre":
                Lines[4].SetActive(true);
                break;
            case "ToarulleBortomSL":
                Lines[5].SetActive(true);
                break;
            case "ToarulleEntreToa":
                Lines[6].SetActive(true);
                break;
            case "ToarulleFooBar":
                Lines[3].SetActive(true);
                break;
            default:
                break;

        }
    }


    public void DoWin()
    {
        Time.timeScale = 0.1f;
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
