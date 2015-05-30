using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class _MenuButtonsScript : MonoBehaviour {
    // === Variables
    public Color32[] colors;
    // Indexes: 0 - White, 1 - Gray

    // ===== OnClick Functions ===== //
    // === Credits Button
    public void OnCreditsBtnClick()
    {

    }

    // === Select Gamemode Button
    public void OnSelectBtnClick(int i)
    {
        PlayerPrefs.SetInt("ScreenToLoad", i);
        Application.LoadLevel("MainScene");
        
    }

    // === Title Menu Button
    public void OnTitleBtnClick()
    {

    }

    // === Music Button
    public void OnMusicBtnClick()
    {
        if (GetComponent<Image>().color == colors[0])
            GetComponent<Image>().color = colors[1];
        else
            GetComponent<Image>().color = colors[0];
    }

    // === SFX Button
    public void OnSFXBtnClick()
    {
        if (GetComponent<Image>().color == colors[0])
            GetComponent<Image>().color = colors[1];
        else
            GetComponent<Image>().color = colors[0];
    }
    // ============================= //
}
