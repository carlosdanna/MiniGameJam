using UnityEngine;
using System.Collections;

public class _TempRenderTextureScript : MonoBehaviour {
    // === Variables
    Texture2D tex;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine("CaptureRenderTexture");
        }
	}

    Texture2D ExtractTextureFromView()
    {
        RenderTexture rt = new RenderTexture(Camera.main.pixelWidth, Camera.main.pixelHeight, 24);
        rt.antiAliasing = 4;
        Camera.main.targetTexture = rt;
        Camera.main.Render();
        Texture2D texture = new Texture2D(rt.width, rt.height);
        texture.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);

        Color[] pixelColors = texture.GetPixels();
        for (int i = 0; i < 10; i++)
            print(pixelColors[i]);

        Camera.main.targetTexture = null;

        return texture;
    }

    IEnumerator CaptureRenderTexture()
    {
        yield return new WaitForEndOfFrame();
        tex = ExtractTextureFromView();
    }
}
