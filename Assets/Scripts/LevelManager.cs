using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public GameObject ScoreScreen;
    public GameObject NextLevelButton;
    public GameObject RetryButton;
    public int ScoreThreshold;
    public Text ScoreText;
    public bool CanPause = true;
    private bool paused;
    public GameObject PauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape) && CanPause) {
            TogglePause();;
	    }
	}

    public void TogglePause () {
        paused = !paused;
        if (paused) {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
        else {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
        }
    }

    public void EndGame (int score) {
        Time.timeScale = 0;
        ScoreScreen.SetActive(true);
        if (score > ScoreThreshold)
        {
            NextLevelButton.SetActive(true);
            RetryButton.SetActive(false);
        } else
        {
            NextLevelButton.SetActive(false);
            RetryButton.SetActive(true);
        }
        ScoreText.text = "" + score;
    }

    public void NextLevel () {
        Debug.Log("Next Scene: " + SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void TitleScreen () {
        SceneManager.LoadScene("Title Screen");
        Time.timeScale = 1;
    }

    public void ExitGame () {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
