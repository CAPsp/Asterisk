using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    private string s1, s2, s3, s4, s5;

    // Use this for initialization
    void Start () {
        s1 = "Debug Start";
        s2 = "Streaming Path ";
        s3 = Application.streamingAssetsPath;
        s4 = "Data Path ";
        s5 = Application.dataPath;
        Debug.Log(s1);
        //ストリーミングアセットのパス
        Debug.Log(s2 + s3);
        //Unityが利用するデータが保存されるパス
        Debug.Log(s4 + s5);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
