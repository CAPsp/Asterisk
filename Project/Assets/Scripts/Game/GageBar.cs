using UnityEngine;
using System.Collections;

public class GageBar : MonoBehaviour {

	[SerializeField] float mConsumePerSecond = 50f;	// 1秒で何power減るか
	[SerializeField] float mLimitPower = 550f;
	[SerializeField] GameObject mDisplayEffect;

	RectTransform mRectTransform;
	float mPower;
	AudioSource mAudioSource;

	void Awake(){
		mRectTransform 	= GetComponent<RectTransform>();
		mPower 			= 0f;
		mAudioSource 	= GetComponent<AudioSource> ();
	}
		
	// falseでGameOver
	public bool ConsumePower(float value){
		mPower += value;

		// GameOver
		if (mLimitPower <= mPower) {
			mAudioSource.Play ();
			mRectTransform.sizeDelta = new Vector2(mLimitPower, mRectTransform.sizeDelta.y);
			mDisplayEffect.SetActive (true);
			return false;
		}

		mRectTransform.sizeDelta = new Vector2(mPower, mRectTransform.sizeDelta.y);
		return true;
	}

	public float GetConsumePerSecond(){
		return mConsumePerSecond;
	}

}
