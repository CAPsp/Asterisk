using UnityEngine;
using System.Collections;

public class Clear : MonoBehaviour {

	[SerializeField] GameObject mClearUI;

	static bool mIsClear;

	void Awake(){
		mIsClear = false;
	}

	// Update is called once per frame
	void Update () {

		if (mIsClear) {
			AudioSource audio = GameObject.FindGameObjectWithTag ("BGM").GetComponent<AudioSource> ();
			audio.Stop();
			audio.clip = GetComponent<AudioSource> ().clip;
			audio.Play();

			mClearUI.SetActive (true);
			Destroy (gameObject);
		}

	}

	public static void FinishGame(){
		mIsClear = true;
	}
}
