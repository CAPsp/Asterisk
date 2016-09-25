using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

    public float fadeTime = 1.0f;
    public GameObject imageObject;
    public string nextScene;

    private bool changeToGame = false;
    private float currentRemainTime;
    private float red, green, blue;
    private Image imageComponet;
    public AudioClip audioClip;
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        currentRemainTime = fadeTime;
        imageComponet = imageObject.GetComponent<Image>();
        red = imageComponet.color.r;
        green = imageComponet.color.g;
        blue = imageComponet.color.b;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (changeToGame == true)
        {
            currentRemainTime -= Time.deltaTime;

            if (currentRemainTime <= 0.0f)
            {
                SceneManager.LoadScene(nextScene);
                return;
            }

            float alpha = currentRemainTime / fadeTime;
            alpha = 1 - alpha;
            imageComponet.color = new Color(red, green, blue, alpha);
        }
    }

    public void onClick()
    {
        changeToGame = true;
        audioSource.Play();
    }
}
