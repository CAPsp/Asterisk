using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Original.Util;

public class Sucker : MonoBehaviour {

	[SerializeField] GameObject mPrefabLine;

	Rigidbody2D mRigidbody;
	HitPointManager mHitPointManager;
	float mSpeed;

	void Awake(){
		mRigidbody 			= GetComponent<Rigidbody2D>();
		mHitPointManager 	= GetComponent<HitPointManager>();
	}

	void Start(){
		GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
		newPrefab.GetComponent<LineRenderer> ().SetPosition (0, transform.position + Vector3.back);
		mHitPointManager.AddLineObject (newPrefab);
		mHitPointManager.AddHitPoint (Vec3ToVec2.GenV3ToV2(transform.position));

		mSpeed = mRigidbody.velocity.magnitude;
	}

	void Update(){

		Debug.Log (mRigidbody.velocity);

		// 無理やり速度を一定にする
		if (mSpeed != mRigidbody.velocity.magnitude) {
			mRigidbody.velocity = mSpeed * mRigidbody.velocity.normalized;
		}

		List<GameObject> lineList 	= mHitPointManager.GetLineList();

		// 最後に当たった場所からSuckerへの線を引く
		lineList[lineList.Count - 1].GetComponent<LineRenderer>().SetPosition(1, transform.position + Vector3.back);

	}

	// 壁の反対
	void OnTriggerEnter2D(Collider2D other){

		float vx = mRigidbody.velocity.x;
		float vy = mRigidbody.velocity.y;
		if (other.transform.parent.tag == "GameAreaX") {
			mRigidbody.velocity = new Vector2(vx * (-1), vy);
		}
		else if(other.transform.parent.tag == "GameAreaY"){

			// 底面に戻ってきたらキャンセルして移動モードに移行
			if(other.transform.position.y < 0){
				ChangeMoving ();
				return;
			}

			mRigidbody.velocity = new Vector2(vx, vy * (-1));
		}

		// 新しい反射角の追加
		mHitPointManager.AddHitPoint (transform.position);

		// 前のLineをここで止めて、新しいLineを追加
		GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
		newPrefab.GetComponent<LineRenderer> ().SetPosition (0, transform.position + Vector3.back);
		mHitPointManager.AddLineObject (newPrefab);
		List<GameObject> lineList = mHitPointManager.GetLineList();
		lineList [lineList.Count - 2].GetComponent<LineRenderer> ().SetPosition (1, transform.position + Vector3.back);

	}

	// ぶつかったら
	void OnCollisionEnter2D(Collision2D other){
		
		// モブ、目標星にぶつかったら
		if (other.gameObject.tag == "Star" || other.gameObject.tag == "TargetStar") {
			
			mRigidbody.velocity = Vector2.zero;

			List<GameObject> lineList = mHitPointManager.GetLineList();
			lineList[lineList.Count - 1].GetComponent<LineRenderer>().SetPosition(1, transform.position + Vector3.back);

			ChangePulling (other.gameObject);
		}

		// 反射星にぶつかったら
		else if(other.gameObject.tag == "ReflectStar"){
			
			float x = (other.contacts [0].point - Vec3ToVec2.GenV3ToV2 (other.collider.bounds.center)).x;

			List<Vector2> hitList = mHitPointManager.GetHitPointList ();
			Vector2 travelVec = Vec3ToVec2.GenV3ToV2 (transform.position) - hitList [hitList.Count - 1];
			float rad;
			if (x >= 0f) {	// 右90度
				rad = Mathf.Deg2Rad * -90f;
			}
			else {			// 左90度
				rad = Mathf.Deg2Rad * 90f;
			}

			float tx = travelVec.x * Mathf.Cos (rad) - travelVec.y * Mathf.Sin(rad);
			float ty = travelVec.x * Mathf.Sin (rad) + travelVec.y * Mathf.Cos(rad);
			Vector2 targetVec2 = new Vector2 (tx, ty);

			mRigidbody.velocity = new Vector2(targetVec2.normalized.x * mSpeed, targetVec2.normalized.y * mSpeed);

			// 新しい反射角の追加
			mHitPointManager.AddHitPoint (transform.position);

			// 前のLineをここで止めて、新しいLineを追加
			GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
			newPrefab.GetComponent<LineRenderer> ().SetPosition (0, transform.position + Vector3.back);
			mHitPointManager.AddLineObject (newPrefab);
			List<GameObject> lineList = mHitPointManager.GetLineList();
			lineList [lineList.Count - 2].GetComponent<LineRenderer> ().SetPosition (1, transform.position + Vector3.back);

		}

	}

	// 引っ張りフェーズに移行
	void ChangePulling(GameObject star){
		GetComponent<Pull> ().enabled = true;
		GetComponent<Pull> ().Initialize (star);
		this.enabled = false;
	}

	// キャンセルして移動フェーズに移行
	void ChangeMoving(){
		mHitPointManager.Reset ();
		GameObject.FindGameObjectWithTag ("Player").GetComponent<ArrowMovement> ().enabled = true;
		Destroy (gameObject);
	}
//
////	void RealCalc(){
//		Vector2 pointInColl = other.contacts[0].point - Vec3ToVec2.GenV3ToV2 (other.collider.bounds.center);
//		float xSign = pointInColl.x / Mathf.Abs(pointInColl.x);
//		float ySign = pointInColl.y / Mathf.Abs(pointInColl.y);
//		Vector2 normalVec2 = new Vector2(1f * xSign, 1f * ySign);
//
//		List<Vector2> hitList = mHitPointManager.GetHitPointList ();
//		Vector2 travelVec = Vec3ToVec2.GenV3ToV2 (transform.position) - hitList [hitList.Count - 1];
//
//		Vector2 tmp = new Vector2(-1f * travelVec.x, -1f * travelVec.y);
//		float dot = Vector2.Dot (tmp, normalVec2) * 2f;
//		tmp = new Vector2 (dot * normalVec2.x, dot * normalVec2.y);
//		tmp = tmp + travelVec;
//		mRigidbody.velocity = new Vector2(tmp.normalized.x * mRigidbody.velocity.magnitude, tmp.normalized.y * mRigidbody.velocity.magnitude);
//
////	}
}
