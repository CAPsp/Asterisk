using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

	public float fadeTime = 1.0f;
	private bool endFade = false;
	private float currentRemainTime;
	private float red, green, blue;

	// Use this for initialization
	void Start()
	{
		currentRemainTime = 0;
		red = GetComponent<Image>().color.r;
		green = GetComponent<Image>().color.g;
		blue = GetComponent<Image>().color.b;
	}

	// Update is called once per frame
	void Update()
	{
		if (currentRemainTime > fadeTime)
		{
			endFade = true;
		}

		if (endFade == false)
		{
			currentRemainTime += Time.deltaTime;


			float alpha = currentRemainTime / fadeTime;

			Debug.Log (alpha);

			GetComponent<Image>().color = new Color(red, green, blue, alpha);
		}

	}
}
