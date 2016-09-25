using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("Debug Start");
        //ストリーミングアセットのパス
        Debug.Log("Streaming Path" + Application.streamingAssetsPath);
        //Unityが利用するデータが保存されるパス
        Debug.Log("Data Path" + Application.dataPath);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
