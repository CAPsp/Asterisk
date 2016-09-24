using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Original.Util;

public class Sucker : MonoBehaviour {

	[SerializeField] GameObject mPrefabLine;

	Rigidbody2D mRigidbody;
	HitPointManager mHitPointManager;
	List<GameObject> mLineList;

	void Awake(){
		mRigidbody 			= GetComponent<Rigidbody2D>();
		mHitPointManager 	= GetComponent<HitPointManager>();

		mLineList  = new List<GameObject>();
		GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
		newPrefab.GetComponent<LineRenderer> ().SetPosition (0, transform.position + Vector3.back);
		mLineList.Add (newPrefab);
	}

	void Update(){

		// 当たった場所があったら線を引く。(そのためには前に当たった場所を順に追跡する)
		List<Vector2> tmp = mHitPointManager.GetHitPointList();
		for(int i = 0; i < tmp.Count; i++){

			if (i + 2 > mLineList.Count) {
				mLineList [mLineList.Count - 1].GetComponent<LineRenderer>().SetPosition (1, new Vector3(tmp[i].x, 	tmp[i].y,	-1));

				GameObject newPrefab = Instantiate (mPrefabLine, Vector3.zero, Quaternion.identity) as GameObject;
				newPrefab.GetComponent<LineRenderer> ().SetPosition (0, new Vector3(tmp[i].x, 	tmp[i].y,	-1));

				mLineList.Add (newPrefab);
			}

		}

		// 最後に当たった場所からSuckerへの線を引く
		mLineList[mLineList.Count - 1].GetComponent<LineRenderer>().SetPosition(1, transform.position + Vector3.back);

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
		}

	}

}
