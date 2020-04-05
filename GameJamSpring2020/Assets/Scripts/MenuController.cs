using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MenuContent;
    public GameObject Controls;

    private void OnEnable()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ShowControls()
    {
        if(Controls.activeSelf == true)
        {
            MenuContent.SetActive(true);
            Controls.SetActive(false);
        } else if(Controls.activeSelf == false)
        {
            MenuContent.SetActive(false);
            Controls.SetActive(true);
        }
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit(0);
    }
}
