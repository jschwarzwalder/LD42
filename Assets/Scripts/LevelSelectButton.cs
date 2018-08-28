using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelectButton : MonoBehaviour
{

    public int LevelIndex;

    private Button button;

    // Use this for initialization
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelIndex, LoadSceneMode.Single);
    }


}
