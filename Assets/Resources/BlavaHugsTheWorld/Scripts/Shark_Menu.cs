using UnityEngine;
using System.Collections;

public class Shark_Menu : MonoBehaviour 
{
    public GameObject panel;

    public void StartGame()
    {
        gameObject.SetActive(false);
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
}
