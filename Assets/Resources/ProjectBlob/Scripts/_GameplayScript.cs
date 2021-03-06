﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class _GameplayScript : MonoBehaviour {
    // === Variables
    public GameObject HUDTimer;
    public GameObject HUDText;
    public GameObject TextBackImage;
    public GameObject RedScore;
    public GameObject BlueScore;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Button;
    public GameObject MusicAudio;
    float m_fTimer;
    State m_State;
    Texture2D tex;
    int m_iCurrentPixel;
    int PlayerOneScore = 0, PlayerTwoScore = 0;
    Player winner = Player.UNKNOWN;

    // === Enums
    enum State { INTRO = 0, PLAY = 1, END = 2, FINISH = 3 };
    enum Player { UNKNOWN = 0, RED = 1, BLUE = 2 };

	// Use this for initialization
	void Start () {
        // Starting state
        m_State = State.INTRO;
        // Initial Timer
        m_fTimer = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
        switch (m_State)
        {
            case State.INTRO:
                GameIntro();
                break;
            case State.PLAY:
                GamePlay();
                break;
            case State.END:
                GameEnd();
                break;
            case State.FINISH:
                GameFinsh();
                break;
        }
	}

    // ===== Game State Functions ===== //
    void GameIntro()
    {
        // Update the timer
        m_fTimer -= Time.deltaTime;
        if (m_fTimer < 1) {
            HUDText.GetComponent<Text>().text = "Paint!";
            if (Camera.main.GetComponent<_SoundManagerScript>().IsAudioTypeEnabled(0))
                MusicAudio.gameObject.SetActive(true);
        }
        else if (m_fTimer < 2)
            HUDText.GetComponent<Text>().text = "Set ...";

        // Time to Switch into the next State?
        if (m_fTimer <= 0.0f)
        {
            // Set the Timer
            m_fTimer = 30.0f;
            // Enable the Timer
            HUDTimer.gameObject.SetActive(true);
            HUDTimer.GetComponent<Text>().text = (int)m_fTimer + "s";
            // Disable the HUDText
            HUDText.gameObject.SetActive(false);
            TextBackImage.gameObject.SetActive(false);
            // Create the Players
            Player1 = Instantiate<GameObject>(Player1) as GameObject;
            Player2 = Instantiate<GameObject>(Player2) as GameObject;
            // Set the State
            m_State = State.PLAY;
        }
    }

    void GamePlay()
    {
        // Update the timer
        m_fTimer -= Time.deltaTime;
        // Setting the Timer
        HUDTimer.GetComponent<Text>().text = (int)m_fTimer + "s";
        // Time to Switch to the Next State?
        if (m_fTimer <= 0.0f)
        {
            // Delete the Players
            Player1.gameObject.SetActive(false);
            Player2.gameObject.SetActive(false);
            // Disable the HUDTimer
            HUDTimer.gameObject.SetActive(false);
            // Extract the Pixels
            StartCoroutine("CaptureRenderTexture");
            // Enable the HUDText
            TextBackImage.gameObject.SetActive(true);
            HUDText.gameObject.SetActive(true);
            HUDText.GetComponent<Text>().text = "Times Up!";
            HUDText.GetComponent<Text>().color = Color.black;
            // Set the State
            m_State = State.END;
        }
    }

    void GameEnd()
    {
        // Determine the Winner
        if (winner == Player.UNKNOWN)
        {
            // Run the Calculation
            winner = DetermineWinner();
        }
        else
        {
            if (!Camera.main.GetComponent<_SoundManagerScript>().IsAudioPlaying(5))
                Camera.main.GetComponent<_SoundManagerScript>().PlayAudio(_SoundManagerScript.SoundID.bScore);
            if (DisplayScores())
            {
                // Display the Winner
                if (winner == Player.RED)
                    HUDText.GetComponent<Text>().text = "Red Wins!";
                else
                    HUDText.GetComponent<Text>().text = "Blue Wins!";
                Camera.main.GetComponent<_SoundManagerScript>().PlayAudio(_SoundManagerScript.SoundID.bVictory);
                // Set the next State
                m_State = State.FINISH;
                Button.SetActive(true);
            }
        }
    }

    void GameFinsh()
    {
        
    }
    // ================================ //

    // ===== Helper Functions ===== //
    Player DetermineWinner()
    {
        Color[] pixels = tex.GetPixels();
        for (int i = 0; m_iCurrentPixel < pixels.Length && i < 500; m_iCurrentPixel += 50, i++)
        {
            if (pixels[m_iCurrentPixel] == Color.red)
                PlayerOneScore++;
            else if (pixels[m_iCurrentPixel] == Color.blue)
                PlayerTwoScore++;
        }
        if (m_iCurrentPixel >= pixels.LongLength)
            return PlayerOneScore > PlayerTwoScore ? Player.RED : Player.BLUE;

        return Player.UNKNOWN;
    }

    // === Function to add a counting effect to the players scores
    // Only returns true once both scores have been fully Displayed, which indicates to move on
    bool DisplayScores()
    {
        // Updating Red Score
        int red = int.Parse(RedScore.GetComponent<Text>().text);
        if (red < PlayerOneScore) {
            red += 2;
            RedScore.GetComponent<Text>().text = (red).ToString();
        }
        // Updating Blue Score
        int blue = int.Parse(BlueScore.GetComponent<Text>().text);
        if (blue < PlayerTwoScore) {
            blue += 2;
            BlueScore.GetComponent<Text>().text = (blue).ToString();
        }
        // Is it finished?
        if (red >= PlayerOneScore && blue >= PlayerTwoScore) {
            RedScore.GetComponent<Text>().text = (PlayerOneScore).ToString();
            BlueScore.GetComponent<Text>().text = (PlayerTwoScore).ToString();
            return true;
        }
        return false;
    }
    // ============================ //

    // ===== Pixel Extraction Functions ===== //
    Texture2D ExtractTextureFromView()
    {
        RenderTexture rt = new RenderTexture(Camera.main.pixelWidth, Camera.main.pixelHeight, 24);
        rt.antiAliasing = 4;
        Camera.main.targetTexture = rt;
        Camera.main.Render();
        Texture2D texture = new Texture2D(rt.width, rt.height);
        texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);

        Camera.main.targetTexture = null;

        return texture;
    }

    IEnumerator CaptureRenderTexture()
    {
        yield return new WaitForEndOfFrame();
        tex = ExtractTextureFromView();
    }
     // ===================================== //
}
