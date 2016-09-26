using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == "Star" || other.gameObject.tag == "TargetStar") {

			GameObject tmp = GameObject.FindGameObjectWithTag ("Sucker");
			if (tmp != null) {
				tmp.GetComponent<Pull> ().ChangeMoving ();
			}
		}

	}

}
