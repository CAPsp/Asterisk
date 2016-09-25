using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Original.Util;

public class Sucker : MonoBehaviour {

	[SerializeField] GameObject mPrefabLine;

	Rigidbody2D mRigidbody;
	HitPointManager mHitPointManager;
	Pull mPull;

	void Awake(){
		mRigidbody 			= GetComponent<Rigidbody2D>();
		mHitPointManager 	= GetComponent<HitPointManager>();
		mPull 				= GetComponent<Pull>();
	}

	void Start(){
		GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
		newPrefab.GetComponent<LineRenderer> ().SetPosition (0, transform.position + Vector3.back);
		mHitPointManager.AddLineObject (newPrefab);
		mHitPointManager.AddHitPoint (Vec3ToVec2.GenV3ToV2(transform.position));
	}

	void Update(){

		// 当たった場所があったら線を引く。(そのためには前に当たった場所を順に追跡する)
		List<Vector2> hitList 		= mHitPointManager.GetHitPointList();
		List<GameObject> lineList 	= mHitPointManager.GetLineList();
		for(int i = 1; i < hitList.Count; i++){

			if (i + 2 > lineList.Count) {
				lineList[lineList.Count - 1].GetComponent<LineRenderer>().SetPosition (1, new Vector3(hitList[i].x, hitList[i].y, -1));

				GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
				newPrefab.GetComponent<LineRenderer> ().SetPosition (0, new Vector3(hitList[i].x, hitList[i].y,	-1));

				lineList.Add (newPrefab);
			}

		}

		// 最後に当たった場所からSuckerへの線を引く
		lineList[lineList.Count - 1].GetComponent<LineRenderer>().SetPosition(1, transform.position + Vector3.back);

	}

	void OnTriggerEnter2D(Collider2D other){

		float vx = mRigidbody.velocity.x;
		float vy = mRigidbody.velocity.y;
		if (other.transform.parent.tag == "GameAreaX") {
			mRigidbody.velocity = new Vector2(vx * (-1), vy);
		}
		else if(other.transform.parent.tag == "GameAreaY"){
			mRigidbody.velocity = new Vector2(vx, vy * (-1));
		}

		mHitPointManager.AddHitPoint (mRigidbody.transform.position);

	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "Star") {
			
			mRigidbody.velocity = Vector2.zero;

			List<GameObject> lineList 	= mHitPointManager.GetLineList();
			lineList[lineList.Count - 1].GetComponent<LineRenderer>().SetPosition(1, transform.position + Vector3.back);

			mPull.Initialize (other);
			mPull.enabled = true;
		}

	}

}
