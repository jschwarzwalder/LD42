using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RetrieveHighScore : MonoBehaviour {

    int levelScore;
    [SerializeField] Text ScoreDisplay;

	// Use this for initialization
	void Start () {

        LevelSelectButton levelButton =  GetComponentInParent<LevelSelectButton>();
        //Get Level Number
        int level = levelButton.LevelIndex;

        //Look up Score
        levelScore = PlayerPrefs.GetInt("Level" + level);

        //Display Score
        if (levelScore > 1)
        {
            ScoreDisplay.text = "High Score: " + levelScore;
        }
        else
        {
            ScoreDisplay.text = "Unplayed";
        }
       

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
