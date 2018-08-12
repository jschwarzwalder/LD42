using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertWindow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    Open();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open () {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Close () {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
