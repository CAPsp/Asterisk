using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

	[SerializeField] float mIgnoreDistance 	= 1.0f;	// タッチしても移動しない時の距離
	[SerializeField] float mMoveSpeed 		= 2f;

	float mMovePointX = float.MaxValue;

	// Update is called once per frame
	void Update () {

		// 移動中
		if(mMovePointX != float.MaxValue){
			Movement ();
		}

		if (Input.touchCount > 0){// && Input.GetTouch (0).position) {

			Touch touch = Input.GetTouch(0);
			if (Mathf.Abs (touch.position.x - transform.position.x) > mIgnoreDistance) {
				mMovePointX = touch.position.x;
			}

			Debug.Log (Input.GetTouch (0).position);
		}
			
	}

	void Movement(){

		float x = Mathf.Lerp(transform.position.x, mMovePointX, Time.deltaTime * mMoveSpeed);
		transform.position = new Vector2(x, transform.position.y);

		if (Mathf.Abs (mMovePointX - transform.position.x) > mIgnoreDistance) {
			mMovePointX = float.MaxValue;
		}

	}
}
