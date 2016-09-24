using UnityEngine;
using System.Collections;

public class Sucker : MonoBehaviour {

	Collider2D mColliderAreaX;
	Collider2D mColliderAreaY;
	Rigidbody2D mRigidbody;

	void Awake(){
		mRigidbody = GetComponent<Rigidbody2D>();
		GameObject gameArea = GameObject.FindWithTag("GameArea");
		mColliderAreaX = (gameArea.GetComponentsInChildren<Collider2D>())[0];
		mColliderAreaY = (gameArea.GetComponentsInChildren<Collider2D>())[1];
	}

	void OnTriggerExit2D(Collider2D other){

		float vx = mRigidbody.velocity.x;
		float vy = mRigidbody.velocity.y;
		if (other == mColliderAreaX) {
			mRigidbody.velocity = new Vector2(vx * (-1), vy);
		}
		else if(other == mColliderAreaY){
			mRigidbody.velocity = new Vector2(vx, vy * (-1));
		}

	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "Star") {
			mRigidbody.velocity = Vector2.zero;
		}

	}

}
