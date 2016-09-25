using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{

    public float fadeTime = 1.0f;
    private float currentRemainTime;
    private bool invisible = true;
    private float totalTime = 0.0f;
    private float startTime = 2.0f;
    private bool start = false;

    private float red, green, blue;

    // Use this for initialization
    void Start()
    {
        currentRemainTime = fadeTime;
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;

    }

    // Update is called once per frame
    void Update()
    {
        if(start == false)
        {
            totalTime += Time.deltaTime;
            if (totalTime < startTime) start = true;
        } else
        {
            if(invisible == true)
            {
                currentRemainTime -= Time.deltaTime;
                float alpha = currentRemainTime / fadeTime;
                alpha = 1 - alpha;
                GetComponent<Image>().color = new Color(red, green, blue, alpha);
                if (currentRemainTime <= 0) invisible = false;
            } else
            {
                currentRemainTime += Time.deltaTime;
                float alpha = currentRemainTime / fadeTime;
                //alpha = 1 - alpha;
                GetComponent<Image>().color = new Color(red, green, blue, alpha);
                if (currentRemainTime >= 0) invisible = true;
            }
        }

    }
}
