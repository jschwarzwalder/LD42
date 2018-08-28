using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    [SerializeField]
    private string[] levelNames;

    [SerializeField]
    private GameObject buttonPrefab;

    [SerializeField]
    private Vector2 firstButtonPosition;

    [SerializeField]
    private Vector2 buttonSpacing;

    [SerializeField]
    private float maxWidth;

    // Use this for initialization
    void Start()
    {
        Vector2 position = firstButtonPosition;
        Vector2 buttonDimensions = buttonPrefab.GetComponent<RectTransform>().localScale;
        for (int i = 0; i < levelNames.Length; ++i)
        {
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponent<RectTransform>().position = position;
            button.GetComponent<LevelSelectButton>().LevelIndex = i;
            button.GetComponentInChildren<Text>().text = levelNames[i];

            position.x += buttonSpacing.x;
            if (position.x + buttonDimensions.x > maxWidth)
            {
                position.y += buttonSpacing.y;
                position.x = firstButtonPosition.x;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(levelNames[index]);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
