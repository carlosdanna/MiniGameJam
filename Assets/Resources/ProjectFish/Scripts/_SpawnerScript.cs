using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class _SpawnerScript : MonoBehaviour {

	public List<GameObject> rightSpawnPoints;
	public List<GameObject> leftSpawnPoints;
	public GameObject currentSeagull = null;
	public bool seagullInFlight = false;
	public float betweenTimer = 0.0f;
	public Text score;
	public int scoreNum = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SpawnCheck ())
			Spawn ();

		if (currentSeagull != null) 
			CheckCurrentSeagull ();

	}

	bool SpawnCheck()
	{
		betweenTimer -= Time.deltaTime;
		return (!seagullInFlight && betweenTimer < 0.0f);
	}

	bool CheckCurrentSeagull()
	{
		if (currentSeagull.transform.position.x < 0.0f || currentSeagull.transform.position.x > 20.0f)
		{
			Destroy(currentSeagull);
			currentSeagull = null;
			seagullInFlight = false;
			betweenTimer = (float)Random.Range (1, 2);
			return false;
		}
		return true;
	}

	void Spawn()
	{
		int point = Random.Range (0, 3);

		int right = Random.Range (0, 2);

		bool isRight = (right == 1) ? true : false;

		GameObject gull = null;
		if (isRight) {
			gull = (GameObject)Instantiate ((GameObject)Resources.Load ("ProjectFish/Prefabs/FS_RightSeagull"), rightSpawnPoints [point].transform.position, Quaternion.identity);
			gull.GetComponent<_RightSeagullScript>().spawner = this;
		} else {
			gull = (GameObject)Instantiate ((GameObject)Resources.Load ("ProjectFish/Prefabs/FS_LeftSeagull"), leftSpawnPoints [point].transform.position, Quaternion.identity);
			gull.GetComponent<_LeftSeagullScript>().spawner = this;
		}

		seagullInFlight = true;
		currentSeagull = gull;
	}
}
