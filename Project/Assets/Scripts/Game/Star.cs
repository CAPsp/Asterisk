using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D other) {

		if (other.gameObject.tag == gameObject.tag) {

			Debug.Log ("True");

			GameObject tmp = GameObject.FindGameObjectWithTag ("Sucker");
			if (tmp != null) {
				tmp.GetComponent<Pull> ().ChangeMoving ();
			}
		}

	}

}
