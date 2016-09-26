using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

	[SerializeField] float mMoveSpeed 		= 2f;
	[SerializeField] float mRadius			= 3f;				// 中心から側面までの距離
	[SerializeField] float mTouchLimitY		= -4f;				// これより下をタッチしたら移動判定
	[SerializeField] Sprite mShooter;
	[SerializeField] ArrowAttack mArrowAttack;
	[SerializeField] SpriteRenderer mShootPointRenderer;

	float mIgnoreDistance 	= 0.2f;
	float mMovePointX 		= float.MaxValue;
	Animator mAnimator;

	void Awake(){
		mAnimator = GetComponent<Animator> ();
		mAnimator.SetBool ("Walk", false);
	}

	// Update is called once per frame
	void Update () {
		mAnimator.enabled 			= true;
		mShootPointRenderer.enabled = false;

		// 移動中
		if(mMovePointX != float.MaxValue){
			Movement ();
		}

		// debug
		if (Input.GetKeyUp ("mouse 0")) {
			Vector3 tmp = PointaToPosition.ChangeToPostion(Input.mousePosition);

			if (tmp.y > mTouchLimitY || mRadius < Mathf.Abs(tmp.x)) {
				return;
			}
				
			if (Mathf.Abs (tmp.x - transform.position.x) > mIgnoreDistance) {
				mAnimator.SetBool ("Walk", true);
				mMovePointX = tmp.x;

				if (mMovePointX < transform.position.x) {	// 左
					transform.rotation = Quaternion.AngleAxis(180f, Vector3.up);
				}
				else {	// 右
					transform.rotation = Quaternion.identity;
				}
			}
			else {
				mAnimator.enabled = false;
				GetComponent<SpriteRenderer>().sprite = mShooter;
				ChangeAttack();
			}
				
		}

//		if (Input.touchCount > 0){
//			Touch touch = Input.GetTouch(0);
//			Vector3 tmp = PointaToPosition.ChangeToPostion (new Vector3(touch.position.x, 0f, 0f));
//
//			if (tmp.y > mTouchLimitY || mRadius < Mathf.Abs(tmp.x)) {
//				return;
//			}
//
//			// 移動判定
//			if (Mathf.Abs (tmp.x - transform.position.x) > mIgnoreDistance) {
//				mMovePointX = tmp.x;
//			}
//			else  if(touch.phase == TouchPhase.Ended){	// 狙いうちに移行
//				ChangeAttack();
//			}
//		}
			
	}

	void Movement(){

		float x = Mathf.Lerp(transform.position.x, mMovePointX, Time.deltaTime * mMoveSpeed);
		transform.position = new Vector3(x, transform.position.y, transform.position.z);

		if ((Mathf.Abs (mMovePointX - transform.position.x) <= mIgnoreDistance) || (Mathf.Abs (transform.position.x) > mRadius) ) {
			mAnimator.SetBool ("Walk", false);
			mMovePointX = float.MaxValue;
		}

	}

	// 狙い撃ちに移行
	void ChangeAttack(){
		mArrowAttack.enabled = true;
		this.enabled = false;
	}
}
