using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject ScoreScreen;
    public Text ScoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndGame (int score) {
        Time.timeScale = 0;
        ScoreScreen.SetActive(true);
        ScoreText.text = "" + score;
    }

    public void NextLevel () {
        Debug.Log("Next Scene: " + SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TitleScreen () {
        SceneManager.LoadScene("Title Screen");
    }
}
