using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject SelectGame;
    public Text gameName;
	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("ScreenToLoad") != 1 || PlayerPrefs.GetInt("ScreenToLoad") != 2)
        {
            PlayerPrefs.SetInt("ScreenToLoad", 1);  //if it is 1 = Main Menu 2 = Select Game
        }
        if (PlayerPrefs.GetInt("ScreenToLoad") == 1)
        {
            MainMenu.SetActive(true);
            SelectGame.SetActive(false);
        }
        if (PlayerPrefs.GetInt("ScreenToLoad") == 2)
        {
            MainMenu.SetActive(false);
            SelectGame.SetActive(true); 
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadGame(string gameName)
    {
        Application.LoadLevel(gameName);
    }

    public void Play()
    {
        LoadGame(gameName.text.ToString());
    }

    public void SelectedGame(Button b)
    {
        gameName.text = b.gameObject.name;
        b.GetComponent<Button>().Select();
    }
}
