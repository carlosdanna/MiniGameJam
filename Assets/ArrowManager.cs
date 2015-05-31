using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ArrowManager : MonoBehaviour {
	public GameObject game;
	public Canvas GameOver;
	public List<GameObject> rightSpawnPoints;
	public List<GameObject> leftSpawnPoints;
	public List<GameObject> players;
	public Text winnerText;
	public float betweenTimer = 0.0f;
	public float arrowSpeed = 5.0f;
	public int lastIndex = 0;

	// Use this for initialization
	void Start () {
		betweenTimer = 300 / 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
		betweenTimer -= Time.deltaTime;
		if (betweenTimer < 0.0f) {
			Spawn ();
		}
	}

	void Spawn()
	{
		int point = 0;
		while(point == lastIndex)
			point = Random.Range (0, 6);

		lastIndex = point;
		
		int right = Random.Range (0, 2);
		
		bool isRight = (right == 1) ? true : false;
		
		GameObject arrow = null;
		if (isRight) {
			arrow = (GameObject)Instantiate ((GameObject)Resources.Load ("ProjectJungle/Prefabs/Arrow"), rightSpawnPoints [point].transform.position, Quaternion.identity);
			arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-arrowSpeed, 0.0f);
		} else {
			arrow = (GameObject)Instantiate ((GameObject)Resources.Load ("ProjectJungle/Prefabs/Arrow"), leftSpawnPoints [point].transform.position, Quaternion.identity);
			arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(arrowSpeed, 0.0f);
		}

		arrow.transform.parent = transform;

		betweenTimer = Random.Range (50, 151) / 100.0f;
	}

	void CheckPlayers()
	{
		if (players.Count == 1) {
			EndGame();
		}
	}

	public void RemovePlayer(GameObject player)
	{
		players.Remove (player);
		CheckPlayers ();
	}

	void EndGame()
	{
		winnerText.text = players[0].GetComponent<_JGPlayerScript>().name + " Wins!";
		GameOver.gameObject.SetActive(true);
		game.SetActive(false);
	}
}
