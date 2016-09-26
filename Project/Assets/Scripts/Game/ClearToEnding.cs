using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Original.UI;
using UnityEngine.SceneManagement;

public class ClearToEnding : Clear {

	[SerializeField] GameObject mDisplayEffect;

	WhiteChange mWhiteChange;

	void Awake(){
		Clear.mIsClear = false;
		mWhiteChange = new WhiteChange (mDisplayEffect.GetComponent<Image>(), 0.15f);
	}

	// Update is called once per frame
	void Update () {

		if (Clear.mIsClear) {
			mDisplayEffect.SetActive (true);

			if (mWhiteChange.CallAtUpdateToWhite ()) {
				SceneManager.LoadScene ("Ending");
			}
		}

	}

}
