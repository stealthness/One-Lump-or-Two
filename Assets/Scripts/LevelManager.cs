using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] levels;
    public int currentGameLevelIndex;
    public GameObject currentGameLevel;

    // Start is called before the first frame update
    void Start()
    {
        currentGameLevelIndex = 0;
        LoadLevel(currentGameLevelIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadLevel(int level)
    {
        Debug.Log("<1> LM  LoadLevel " + level);
        currentGameLevelIndex = (level >= levels.Length) ? 0 : level;
        if (currentGameLevel != null)
        {
            Destroy(currentGameLevel);
        }
        gameManager.ResetCube();
        currentGameLevel =  Instantiate(levels[level]);
        PlayerPrefs.SetInt("GameLevel", level);
       
    }

    public void ResetLevel()
    {
        gameManager.ResetCube();
        Debug.Log("<2> LM  ResetLevel " + levels);
        SceneManager.LoadScene("GameScene");
    }
}
