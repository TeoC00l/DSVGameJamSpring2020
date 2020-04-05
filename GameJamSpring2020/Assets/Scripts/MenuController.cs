using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuController : MonoBehaviour
{
    public GameObject MenuContent;
    public GameObject Controls;
    public GameObject VideoScreen;
    public VideoPlayer VideoPlayer;

    private bool startedPlaying = false;
    private bool played = false;

    private void OnEnable()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Update()
    {
        if (startedPlaying && !VideoPlayer.isPlaying)
        {
            LoadScene("SampleScene");
        }
        if(Input.GetKeyDown(KeyCode.Return) && VideoPlayer.isPlaying)
        {
            LoadScene("SampleScene");
        }
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

    public void StartVideo()
    {
        VideoScreen.SetActive(true);
        VideoPlayer.Play();
        startedPlaying = true;
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
