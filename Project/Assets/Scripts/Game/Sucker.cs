using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Original.Util;

public class Sucker : MonoBehaviour {

	[SerializeField] GameObject mPrefabLine;

	Rigidbody2D mRigidbody;
	HitPointManager mHitPointManager;

	void Awake(){
		mRigidbody 			= GetComponent<Rigidbody2D>();
		mHitPointManager 	= GetComponent<HitPointManager>();
	}

	void Start(){
		GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
		newPrefab.GetComponent<LineRenderer> ().SetPosition (0, transform.position + Vector3.back);
		mHitPointManager.AddLineObject (newPrefab);
		mHitPointManager.AddHitPoint (Vec3ToVec2.GenV3ToV2(transform.position));
	}

	void Update(){
		
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
		
		// 星にぶつかったら
		if (other.gameObject.tag == "Star" || other.gameObject.tag == "TargetStar") {
			
			mRigidbody.velocity = Vector2.zero;

			List<GameObject> lineList = mHitPointManager.GetLineList();
			lineList[lineList.Count - 1].GetComponent<LineRenderer>().SetPosition(1, transform.position + Vector3.back);

			ChangePulling (other.gameObject);
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
}
