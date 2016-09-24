using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitPointManager : MonoBehaviour{

	List<Vector2> mHitPoints;

	public void Awake(){
		mHitPoints = new List<Vector2> ();
	}

	public void AddHitPoint(Vector2 item){
		mHitPoints.Add (item);
	}

	public List<Vector2> GetHitPointList(){
		return mHitPoints;
	}

}
