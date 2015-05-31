using UnityEngine;
using System.Collections;

public class _ColorBlockBehavior : MonoBehaviour {
    // === Variables
    public GameObject Gameplay;
    public GameObject BlockPrefab;
    public GameObject HUDScore;
    float m_fSpeed = 500;
    bool m_bInput = true;

    // Use this for initialization
    void Start()
    {
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponentInParent<_GamePlayScript>().CheckIfColorIsActive(GetComponent<SpriteRenderer>().color))
        {
            SetColor();
        }
        if (m_bInput)
        {
            // Left Input
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(-m_fSpeed, 0));
                m_bInput = false;
            }
            // Right Input
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(m_fSpeed, 0));
                m_bInput = false;
            }
            // Up Input
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, m_fSpeed));
                m_bInput = false;
            }
            // Down Input
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -m_fSpeed));
                m_bInput = false;
            }
        }
    }

    // === Collision
    void OnCollisionEnter2D(Collision2D _col)
    {
        // Do the colors match?
        if (_col.gameObject.GetComponent<SpriteRenderer>().color == this.GetComponent<SpriteRenderer>().color)
        {
            // Increase the Player's score

        }
        // Reset the Block
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 0, 0);
        m_bInput = true;
        SetColor();
    }

    // === Choosing a Color
    void SetColor()
    {
        GetComponent<SpriteRenderer>().color = GetComponentInParent<_GamePlayScript>().GetRandomActiveColor();
    }

    
}
