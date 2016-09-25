using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowMovie : MonoBehaviour {

    /*public UILabel label;
    TextReader txtReader;
    string description;*/


    void Start()
    {
        StartCoroutine("LoadOpeningMovie");
    }

    IEnumerator LoadOpeningMovie()
    {
        
        string movieFileName = "Blurry-Lights.mp4";
        string path = "";

		path = Application.streamingAssetsPath +"/" + movieFileName;
		WWW www = new WWW(path);
		yield return www;

        //Debug.Log(www.text);
        Handheld.PlayFullScreenMovie(www.text, Color.black, FullScreenMovieControlMode.CancelOnInput);
        SceneManager.LoadScene("Title");

    }
}
