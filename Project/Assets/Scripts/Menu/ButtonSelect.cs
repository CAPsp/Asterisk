using UnityEngine;
using System.Collections;

public class ButtonSelect : MonoBehaviour {

    //private GameObject Manager;

	// Use this for initialization
	void Start () {
        //Manager = GameObject.Find("StageManager");
        //NumStage nStage = Manager.GetComponent<NumStage>();
        switch (NumStage.numberOfStage)
        {
            case 1:
                GameObject dis1_2 = GameObject.Find("Menu2");
                dis1_2.SetActive(false);
                GameObject dis1_3 = GameObject.Find("Menu3");
                dis1_3.SetActive(false);
                break;
            case 2:
                //GameObject dis2_1 = GameObject.Find("Menu1");
                //dis2_1.SetActive(false);
                GameObject dis2_3 = GameObject.Find("Menu3");
                dis2_3.SetActive(false);
                break;
            case 3:
                //GameObject dis3_1 = GameObject.Find("Menu1");
                //dis3_1.SetActive(false);
                //GameObject dis3_2 = GameObject.Find("Menu2");
                //dis3_2.SetActive(false);
                break;


        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
