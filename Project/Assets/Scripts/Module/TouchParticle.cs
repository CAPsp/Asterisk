using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchParticle : MonoBehaviour {

    public GameObject touchEffect;
    private Touch touch;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Vector3 touchPoint_screen = new Vector3(touch.position.x, touch.position.y, 5);
                Vector3 touchPoint_world = Camera.main.ScreenToWorldPoint(touchPoint_screen);
                Instantiate(touchEffect, touchPoint_world, Quaternion.identity);
            }
        }
    }
}
