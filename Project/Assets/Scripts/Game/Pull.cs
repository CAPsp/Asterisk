using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Original.Util;


public class Pull : MonoBehaviour {

	[SerializeField] float mPullSpeed 			= 1.5f;
	[SerializeField] float mNotifiRadius 		= 1.5f;	// 主人公へのタップを検知する距離範囲
	[SerializeField] float mDestroyLineDistance = 0.1f;
	[SerializeField] AudioClip mPullSE;

	GageBar mGageBar;
	HitPointManager mHitPointManager;
	GameObject mStarObject;
	bool isPulling;

	void Awake(){
		mHitPointManager 	= GetComponent<HitPointManager>();
		mGageBar			= GameObject.FindGameObjectWithTag("Gage").GetComponent<GageBar>();
	}

	void Start(){
		GetComponent<SpriteRenderer> ().enabled = false;
		isPulling = false;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 point = PointaToPosition.ChangeToPostion(Input.mousePosition);
		point = new Vector3(point.x, point.y, 0f);

		if ( Input.GetKey ("mouse 0") &&
			 Vector3.Distance (point, GameObject.FindGameObjectWithTag("Player").transform.position) <= mNotifiRadius ){

			isPulling = true;
			PullProcess ();
		}
		else if (isPulling) {	// 離した(上のif文に入ってないので)
			ChangeMoving();
		}

//		if (Input.touchCount > 0) {
//
//			Touch touch = Input.GetTouch (0);
//			Vector3 point = PointaToPosition.ChangeToPostion(touch.position);
//			point = new Vector3 (point.x, point.y, 0f);
//			if ( touch.phase == TouchPhase.Moved &&
//				 Vector3.Distance (point, GameObject.FindGameObjectWithTag("Player").transform.position) <= mNotifiRadius ){
//
//				isPulling = true;
//				PullProcess ();
//			}
//			else if (isPulling) {	// 離した(上のif文に入ってないので)
//				ChangeMoving();
//			}
//
//		}

	}

	void PullProcess(){

		if (!AudioManager.isPlaying (GetComponent<AudioSource>(), mPullSE)) {
			AudioManager.Play (GetComponent<AudioSource> (), mPullSE);
		}

		// Power減らす
		if (!mGageBar.ConsumePower (Time.deltaTime * mGageBar.GetConsumePerSecond ())) {
			ChangeGameOver ();
			return;
		}

		List<GameObject> lineList 	= mHitPointManager.GetLineList();
		List<Vector2> vecList 		= mHitPointManager.GetHitPointList();

		Vector2 angle = Vec3ToVec2.GenVecFrom2Points (vecList[vecList.Count - 1], mStarObject.transform.position);

		Vector3 posInc = Time.deltaTime * mPullSpeed * new Vector3(angle.normalized.x, angle.normalized.y, 0f);
		mStarObject.transform.position 	+= posInc;
		transform.position 				+= posInc;

		lineList[lineList.Count - 1].GetComponent<LineRenderer>().SetPosition(1, mStarObject.transform.position + Vector3.back);

		// 反射するところに近くなったら消す
		if (mDestroyLineDistance > Vector2.Distance (Vec3ToVec2.GenV3ToV2 (mStarObject.transform.position), vecList [vecList.Count - 1])) {
			vecList.RemoveAt (vecList.Count - 1);
			Destroy (lineList[lineList.Count - 1]);
			lineList.RemoveAt (lineList.Count - 1);

			if (vecList.Count <= 0) {

				// 引き寄せたものがお目当の星だったら
				if(mStarObject.tag == "TargetStar"){
					StageClear ();
				}
				else{
					ChangeMoving ();
				}
			}
		}

	}

	public void Initialize(GameObject star){
		mStarObject = star;
	}

	// 移動モードに移行
	public void ChangeMoving(){
		GameObject.FindGameObjectWithTag ("Player").GetComponent<ArrowMovement> ().enabled = true;
		mHitPointManager.Reset ();
		Destroy (gameObject);
	}

	// ゲームーオーバー判定
	void ChangeGameOver(){
		mHitPointManager.Reset ();
		GameObject.FindGameObjectWithTag ("AllParentObject").SetActive (false);
		Destroy (gameObject);
	}

	// ステージクリア判定
	void StageClear(){
		Clear.FinishGame ();
		mHitPointManager.Reset ();
		GameObject.FindGameObjectWithTag ("AllParentObject").SetActive (false);
		Destroy (gameObject);
	}

}
