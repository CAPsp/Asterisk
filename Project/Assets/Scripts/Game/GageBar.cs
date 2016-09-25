using UnityEngine;
using System.Collections;

public class GageBar : MonoBehaviour {

	[SerializeField] float mConsumePerSecond = 50f;	// 1秒で何power減るか
	[SerializeField] float mLimitPower = 550f;
	[SerializeField] FadeIn mFadeIn;

	RectTransform mRectTransform;
	float mPower;

	void Awake(){
		mRectTransform = GetComponent<RectTransform>();
		mPower = 0f;
	}

	public void ConsumePower(float value){
		mPower += value;

		// GameOver
		if (mLimitPower <= mPower) {
			mRectTransform.sizeDelta = new Vector2(mLimitPower, mRectTransform.sizeDelta.y);
			mFadeIn.enabled = true;
			return;
		}

		mRectTransform.sizeDelta = new Vector2(mPower, mRectTransform.sizeDelta.y);
	}

	public float GetConsumePerSecond(){
		return mConsumePerSecond;
	}

}
