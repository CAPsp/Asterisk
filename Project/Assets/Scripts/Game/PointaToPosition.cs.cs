using UnityEngine;
using System.Collections;

public class PointaToPosition : MonoBehaviour {

	public static Vector3 ChangeToPostion(Vector3 position){
		return Camera.main.ScreenToWorldPoint (position);
	}

}
