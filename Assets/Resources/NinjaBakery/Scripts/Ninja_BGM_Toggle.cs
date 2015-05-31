using UnityEngine;
using System.Collections;

public class Ninja_BGM_Toggle : MonoBehaviour {

	AudioSource[] bgms = new AudioSource[2];
	// Use this for initialization
	void Start () {
		bgms = GetComponents<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlayMenu()
	{
		if (bgms [1].isPlaying) {
			bgms[1].Stop();
		}
		bgms [0].Play ();
	}

	public void PlayLevel()
	{
		if (bgms [0].isPlaying) {
			bgms[0].Stop();
		}
		bgms [1].Play ();
		
	}
}
