using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertWindow : MonoBehaviour {

    private LevelManager gameManager;

	// Use this for initialization
	void Start () {
	    gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<LevelManager>();

	    Open();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open () {
        gameObject.SetActive(true);
        Time.timeScale = 0;
        gameManager.CanPause = false;
    }

    public void Close () {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        gameManager.CanPause = true;
    }
}
