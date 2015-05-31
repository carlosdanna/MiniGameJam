using UnityEngine;
using System.Collections;

public class _ButtonScript : MonoBehaviour {
    // General OnClick Function
    void OnBtnClick()
    {
        AudioSource audio = Camera.main.GetComponent<AudioSource>();
        audio.clip = (AudioClip)Resources.Load("ProjectBlob/Audio/Blob_MenuSelect");
        audio.Play();
    }

    // == Back to Menu Button
    public void OnBackBtnClick()
    {
        Application.LoadLevel("BlobScene");
    }
}
