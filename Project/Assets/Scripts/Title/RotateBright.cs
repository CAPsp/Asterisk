using UnityEngine;
using System.Collections;

public class RotateBright : MonoBehaviour {

    public float angle = 1.0f;

	// Use this for initialization
	void Start () {
        //transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,angle));
    }
}
