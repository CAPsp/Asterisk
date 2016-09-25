using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveToMenu : MonoBehaviour {
    public float fadeTime = 1.0f;
    private bool changeToMenu = false;
    private float currentRemainTime;
    private float red, green, blue;
    private Touch touch;

	// Use this for initialization
	void Start () {
        currentRemainTime = fadeTime;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetMouseButton(0))
        {
            changeToMenu = true;
        }*/

        //タッチがあるかどうか？
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            //タッチ直後
            if (touch.phase == TouchPhase.Began)
            {
                changeToMenu = true;

            }


        }

        if (changeToMenu == true)
        {
            currentRemainTime -= Time.deltaTime;

            if(currentRemainTime <= 0.0f)
            {
                Debug.Log("Debug Start");
                //ストリーミングアセットのパス
                Debug.Log("Streaming Path" + Application.streamingAssetsPath);
                //Unityが利用するデータが保存されるパス
                Debug.Log("Data Path" + Application.dataPath);
                SceneManager.LoadScene("Menu");
                return;
            }

            float alpha = currentRemainTime / fadeTime;
            alpha = 1 - alpha;
            GetComponent<Image>().color = new Color(red, green, blue, alpha);
        }

    }
}
