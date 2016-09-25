using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ShowMovie : MonoBehaviour {

    /*public UILabel label;
    TextReader txtReader;
    string description;*/
    public string videoName;


    void Start()
    {

        //StartCoroutine("LoadOpeningMovie");
        //Handheld.PlayFullScreenMovie(videoPath,Color.black,FullScreenMovieControlMode.CancelOnInput);
        Handheld.PlayFullScreenMovie(videoName, Color.black, FullScreenMovieControlMode.CancelOnInput);
        SceneManager.LoadScene("Title");

    }



    
}
