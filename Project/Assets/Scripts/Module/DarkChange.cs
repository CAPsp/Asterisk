using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Original.UI{

	// 暗転を処理するクラス
	public class DarkChange{

		Image mTargetImage;		// エフェクトをかける対象
		float mSpeed;
		float mAlpha = 0f;

		public DarkChange(Image target, float speed){
			mTargetImage = target;
			mSpeed = speed;

			mTargetImage.color = Color.clear;
		}

		// Update関数で呼び出す暗転処理こと
		// true = 暗転終了
		public bool CallAtUpdateToBlack(){

			mTargetImage.color = new Color (0f, 0f, 0f, mAlpha);
			mAlpha += Time.deltaTime * mSpeed;

			return (mTargetImage.color.a >= 1f);

		}

		// 暗転逆処理
		public bool CallAtUpdateToClear(){

			mTargetImage.color = new Color (0f, 0f, 0f, mAlpha);
			mAlpha -= Time.deltaTime * mSpeed;

			return (mTargetImage.color.a <= 0f);
		}

		public float GetAlpha(){
			return mAlpha;
		}

	}

}