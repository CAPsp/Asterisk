using UnityEngine;
using System.Collections;

public class ManagerChecker : MonoBehaviour {
    public GameObject stageManagerPrefab;
   

	// Use this for initialization
	void Start () {
        GameObject Manager = GameObject.Find("StageManager");
	    if(Manager != null)
        {
            Destroy(Manager);
            Debug.Log("Destroyed");
        }
        Instantiate(stageManagerPrefab);
        Debug.Log("Generated");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
