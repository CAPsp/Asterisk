using UnityEngine;
using System.Collections;

public class ArrowAttack : MonoBehaviour {

	[SerializeField] float mAngleLimit = 60f;

	ArrowMovement mArrowMovement;

	void Awake(){
		mArrowMovement = GetComponent<ArrowMovement> ();
	}

	void Start(){
		mArrowMovement.enabled = false;
	}

	void Update(){

		// debug
		if (Input.GetKey ("mouse 0")) {
			Vector3 diff = PointaToPosition.ChangeToPostion (Input.mousePosition) - transform.position;

			float angle = Mathf.Atan2 (diff.x, diff.y);
			angle = Mathf.Rad2Deg * angle;	// rad→角度
			angle = Mathf.Clamp (angle, (-1) * mAngleLimit, mAngleLimit);

			transform.rotation = Quaternion.AngleAxis (angle, Vector3.back);
		}
		else if(Input.GetKeyUp("mouse 0")){

		}

	}

}
