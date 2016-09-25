using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitPointManager : MonoBehaviour{

	List<Vector2> mHitPoints;
	List<GameObject> mLineList;

	public void Awake(){
		mHitPoints 	= new List<Vector2> ();
		mLineList  	= new List<GameObject>();
	}

	public void AddHitPoint(Vector2 item){
		mHitPoints.Add (item);
	}

	public List<Vector2> GetHitPointList(){
		return mHitPoints;
	}

	public void AddLineObject(GameObject item){
		mLineList.Add (item);
	}

	public List<GameObject> GetLineList(){
		return mLineList;
	}

}
