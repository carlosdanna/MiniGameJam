using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class _GamePlayScript : MonoBehaviour {
    // === Enums
    enum State { Enter, Gameplay, GameOver, Exit };

    // === Variables
    public GameObject[] m_Walls;
    public GameObject BlockPrefab;
    List<Color> m_ActiveColors = new List<Color>(4);
    float m_fRandomizeTimer;
    float m_fGameTimer;
    State m_State;

	// Use this for initialization
	void Start () {
        // Randomize the Wall Colors
        RandomizeWallColors();
        // Start in the Enter State
        m_State = State.Enter;
	}
	
	// Update is called once per frame
	void Update () {
	    switch(m_State)
        {
            case State.Enter:
                Enter();
                break;
            case State.Gameplay:
                Gameplay();
                break;
            case State.GameOver:
                GameOver();
                break;
            case State.Exit:
                Exit();
                break;
        }
	}

    // ===== Game State Functions ===== //
    void Enter()
    {
        // Get Ready ...
        m_fGameTimer -= Time.deltaTime;
        if (m_fGameTimer <= 0.0f) {
            // Switch to the next State
            m_State = State.Gameplay;
            // Setup for the Next State
            m_fRandomizeTimer = 8.0f;
            m_fGameTimer = 60.0f;
        }
    }

    void Gameplay()
    {
        // Update both timers
        m_fGameTimer -= Time.deltaTime;
        m_fRandomizeTimer -= Time.deltaTime;
        // Randomize Timer?
        if (m_fRandomizeTimer <= 0.0f)
        {
            RandomizeWallColors();
            m_fRandomizeTimer = 8.0f;
        }
        // Game Timer?
        if (m_fGameTimer <= 0.0f)
        {
            // Switch to the next State
            m_State = State.GameOver;
            // Set up for the Next State
        }
    }

    void GameOver()
    {

    }

    void Exit()
    {

    }
    // ================================ //

    // ===== Color Related Functions ===== //
    void RandomizeWallColors()
    {
        // Clear out the old colors
        m_ActiveColors.Clear();
        for (int i = 0; i < 4; i++)
        {
            m_Walls[i].GetComponent<SpriteRenderer>().color = GetRandomColor();
        }
    }

    Color GetRandomColor()
    {
        Color color;
        while (true)
        {
            int selector = Random.Range(0, 10);
            switch (selector)
            {
                case 1:
                    color = Color.red;
                    break;
                case 2:
                    color = Color.magenta;
                    break;
                case 3:
                    color = Color.green;
                    break;
                case 4:
                    color = Color.white;
                    break;
                case 5:
                    color = Color.yellow;
                    break;
                case 6:
                    color = Color.grey;
                    break;
                case 7:
                    color = Color.blue;
                    break;
                case 8:
                    color = Color.cyan;
                    break;
                case 9:
                    color = Color.black;
                    break;
                default:
                    color = Color.white;
                    break;
            }
            if (!m_ActiveColors.Contains(color))
                break;
        }
        m_ActiveColors.Add(color);
        return color;
    }

    public Color GetRandomActiveColor()
    {
        if (m_ActiveColors.Count != 0) {
            int selector = Random.Range(0, 4);
            return m_ActiveColors[selector];
        }
        return new Color(0, 0, 0, 0);
    }

    public bool CheckIfColorIsActive(Color _color)
    {
        return m_ActiveColors.Contains(_color);
    }
    // =================================== //
}
