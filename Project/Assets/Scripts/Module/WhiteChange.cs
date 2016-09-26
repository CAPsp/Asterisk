using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Original.UI{

	// ホワイトアウトを処理するクラス
	public class WhiteChange{

		Image mTargetImage;		// エフェクトをかける対象
		float mSpeed;
		float mAlpha = 0f;

		public WhiteChange(Image target, float speed){
			mTargetImage = target;
			mSpeed = speed;

			mTargetImage.color = Color.clear;
		}

		// Update関数で呼び出す暗転処理こと
		// true = 暗転終了
		public bool CallAtUpdateToWhite(){

			mTargetImage.color = new Color (1f, 1f, 1f, mAlpha);
			mAlpha += Time.deltaTime * mSpeed;

			return (mTargetImage.color.a >= 1f);

		}

		// 暗転逆処理
		public bool CallAtUpdateToClear(){

			mTargetImage.color = new Color (1f, 1f, 1f, mAlpha);
			mAlpha -= Time.deltaTime * mSpeed;

			return (mTargetImage.color.a <= 0f);
		}

		public float GetAlpha(){
			return mAlpha;
		}

	}

}