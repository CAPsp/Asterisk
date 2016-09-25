using UnityEngine;
using System.Collections;
using Original.UI;
using UnityEngine.UI;

public class DarkChangeManager : MonoBehaviour {

	[SerializeField] GameObject mGameOver;

	DarkChange mDarkChange;
	bool mWillDark = true;

	void Awake(){
		mDarkChange = new DarkChange (GetComponent<Image>(), 1f);
	}

	void Update(){

		if (mWillDark) {	// 暗転していく
			
			if (mDarkChange.CallAtUpdateToBlack ()) {
				mGameOver.SetActive (true);
				mWillDark = false;
			}
		}
		else {				// 暗転解除
			mDarkChange.CallAtUpdateToClear();
		}

	}

}
