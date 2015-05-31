using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shark_Menu : MonoBehaviour 
{
    public GameObject panel, pausePanel, zeButtons;
    public GameObject image;

    public void StartGame()
    {
        zeButtons.SetActive(false);
        image.SetActive(false);
        GameObject spawner = GameObject.Find("SpawnManager");
        spawner.GetComponent<Shark_SpawnMaster>().Initialize();
        GameObject camera = GameObject.Find("Main Camera");
        camera.GetComponent<Shark_CameraScript>().ZoomToPlayer();
    }

    public void OpenCredits()
    {
        panel.SetActive(true);
    }

    public void CloseCredits()
    {
        panel.SetActive(false);
    }

    public void Quit()
    {
        //Application.LoadLevel("Main Menu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
}
