using UnityEngine;
using System.Collections;
using Original.Util;

public class ArrowAttack : MonoBehaviour {

	[SerializeField] float mAngleLimit = 60f;
	[SerializeField] GameObject mPrefabSucker;
	[SerializeField] float mSpeed = 10.0f;
	[SerializeField] Transform mTargetTrans;
	[SerializeField] GameObject mObjectIncludeLine;

	Vector3 mPosition;
	LineRenderer mFirstLine;

	void Awake(){
		mFirstLine		= GetComponent<LineRenderer>();
	}

	void Update(){

		// debug
		if (Input.GetKey ("mouse 0")) {
			Preparation ();
		}
		else if(Input.GetKeyUp("mouse 0")){
			Fire ();
		}

	}

	void Preparation(){

		mFirstLine.enabled = true;

		// 角度をつける
		Vector3 diff = PointaToPosition.ChangeToPostion (Input.mousePosition) - transform.position;

		float angle = Mathf.Atan2 (diff.x, diff.y);
		angle = Mathf.Rad2Deg * angle;	// rad→角度
		angle = Mathf.Clamp (angle, (-1) * mAngleLimit, mAngleLimit);

		transform.rotation = Quaternion.AngleAxis (angle, Vector3.back);
	
		// ガイドラインが反射する可能性を考慮
		Vector2 vec2Pos = new Vector2(transform.position.x, transform.position.y);
		RaycastHit2D hit = 
			Physics2D.Raycast (	vec2Pos,
								Vec3ToVec2.GenVecFrom2Points (mTargetTrans.position, transform.position).normalized,
								Vec3ToVec2.CalcDistanceOn2D (transform.position, mTargetTrans.position));

		// 反射したかを考えてガイドラインを表示
		if (hit.collider != null) {

			// 一本目の線
			Vector3 middle = new Vector3(hit.point.x, hit.point.y);
			mFirstLine.SetPosition (0, transform.position + Vector3.back);
			mFirstLine.SetPosition (1, middle + Vector3.back);

			// 二本目の線
			float remainLength = Vec3ToVec2.CalcDistanceOn2D (transform.position, mTargetTrans.position)
									- Vec3ToVec2.CalcDistanceOn2D (transform.position, middle);

			Vector2 tmp = Vec3ToVec2.GenVecFrom2Points (mTargetTrans.position, transform.position).normalized;
			Vector3 reflectAngle = new Vector3(tmp.x * (-1), tmp.y, 0);

			mObjectIncludeLine.SetActive(true);
			mObjectIncludeLine.GetComponent<LineRenderer> ().SetPosition (0, middle + Vector3.back);
			mObjectIncludeLine.GetComponent<LineRenderer> ().SetPosition (1, middle + reflectAngle.normalized * remainLength);
			
		}
		else {
			mFirstLine.SetPosition (0, transform.position + Vector3.back);
			mFirstLine.SetPosition (1, mTargetTrans.position + Vector3.back);
			mObjectIncludeLine.SetActive(false);
		}

	}

	void Fire(){

		mFirstLine.enabled = false;
		mObjectIncludeLine.SetActive(false);

		Transform transform = (gameObject.GetComponentsInChildren<Transform>())[1];
		GameObject sucker 	= Instantiate (mPrefabSucker, transform.position, Quaternion.identity) as GameObject;

		Vector3 diff = (mTargetTrans.position - transform.position);
		diff = new Vector3 (diff.x, diff.y, 0f);
		sucker.GetComponent<Rigidbody2D> ().velocity = mSpeed * diff.normalized;

		this.enabled = false;

	}

}
