using UnityEngine;
using System.Collections;

public class Sucker : MonoBehaviour {
	
	Rigidbody2D mRigidbody;

	void Awake(){
		mRigidbody = GetComponent<Rigidbody2D>();
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

	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "Star") {
			mRigidbody.velocity = Vector2.zero;
		}

	}

}
