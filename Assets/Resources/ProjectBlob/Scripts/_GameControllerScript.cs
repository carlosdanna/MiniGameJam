using UnityEngine;
using System.Collections;

public class _GameControllerScript : MonoBehaviour {
	public Rect sourceRect;
	public Texture2D sourceTex;
	public RenderTexture rendTex;
	public int redScore = 0;
	public int blueScore = 0;
	// Use this for initialization
	void Start () {
		sourceTex = new Texture2D (Camera.main.pixelWidth, Camera.main.pixelHeight);
		Evaluate ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Evaluate()
	{
		RenderTexture.active = rendTex;
		sourceTex.ReadPixels(new Rect(0, 0, Camera.main.pixelHeight, Camera.main.pixelWidth), 0, 0);
		sourceTex.Apply();
		// The values in the Rect structure are floats, so round them
		// down to the nearest integer.
		int x1 = Mathf.FloorToInt(Camera.main.transform.position.x);
		int y1 = Mathf.FloorToInt(Camera.main.transform.position.y);
		int width = Mathf.FloorToInt(Camera.main.pixelWidth);
		int height = Mathf.FloorToInt(Camera.main.pixelHeight);
		
		// Get the pixel block and place it into a new texture.
		Color[] pix = sourceTex.GetPixels(x1, y1, width, height);

		for (int x = 0; x < Camera.main.pixelWidth; x++) 
		{
			for (int y = 0; y < Camera.main.pixelHeight; y++) 
			{
				if(pix[y * Camera.main.pixelWidth + x].r > 0.5f)
				{
					redScore++;
				}
				else if(pix[y * Camera.main.pixelWidth + x].g > 0.5f)
				{
					blueScore++;
				}
			}
		}
	}
}
