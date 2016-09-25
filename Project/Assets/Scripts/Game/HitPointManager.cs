using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HitPointManager : MonoBehaviour{

	public List<Vector2> mHitPoints;
	public List<GameObject> mLineList;

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

	public void ResetLineList(){
		foreach(GameObject obj in mLineList){
			Destroy (obj);
		}
		mLineList.Clear ();
	}

	public void ResetHitPoint(){
		mHitPoints.Clear ();
	}

	public void Reset(){
		ResetLineList ();
		ResetHitPoint ();
	}
}
