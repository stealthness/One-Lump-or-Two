using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private readonly float _increaseFactor = 1.1f;
    private readonly float _thrust = 50f;

    public SugarCubeManager cubeManager;
    public UIMenuManager menuManager;
    public LevelManager levelManager;

    public GameObject cube;
    public GameObject arrow;

    private GameObject _insideCup;


    float startPowerBuilding;

    public GameState gameState;
    private ArrowState _arrowState;
    public BonusStatus bonusStatus;

    private int gameLevel;
    public int startLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameLevel = startLevel;
        levelManager.LoadLevel(gameLevel);
        gameState = GameState.Menu;

        arrow.transform.position = cube.transform.position;
        _arrowState = ArrowState.PowerOff;

        _insideCup = GameObject.Find("Inside Cup");
        bonusStatus = BonusStatus.Available;
    }

    internal void ResetCubeTo(Vector3 newPosition)
    {
        cube.transform.position = newPosition;
    }

    public void ResetCube()
    {
        cubeManager.ResetPosition();
    }

    private void Update()
    {
        if (gameState == GameState.Menu)
        {
            return;
        }


        if (_arrowState == ArrowState.Hidden)
        {
            arrow.SetActive(false);
        }

        Vector3 mousePostion = GetWorldMousePos();
        Vector3 direction = (mousePostion - cube.transform.position).normalized;
        float angle=((direction.x < 0 )? 180 : 0)+ Mathf.Rad2Deg * Mathf.Atan(direction.y / direction.x);;
        if (_arrowState != ArrowState.Hidden)
        {

            arrow.transform.position = cube.transform.position;
            arrow.transform.rotation = Quaternion.Euler(0, 0, angle);
        }



        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            startPowerBuilding = 0f;
            _arrowState = ArrowState.PowerOn;
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            //Debug.Log(string.Format("startPowerBuilding: {0}    mousePostion: {1}", startPowerBuilding, mousePostion));
            cubeManager.ShootCube(direction * startPowerBuilding * _thrust);
            arrow.transform.localScale = Vector3.one;
            _arrowState = ArrowState.Hidden;
        }


        if (_arrowState == ArrowState.PowerOn)
        {
            arrow.transform.localScale += Vector3.one * _increaseFactor * Time.deltaTime;
            Debug.Log(string.Format("dir:{0}  cube:{1}  ang:{2}", direction, cube.transform.position , angle));
        }

        if (bonusStatus == BonusStatus.Achieved)
        {
            Debug.Log("Bonus Acheived");
        }

      

        startPowerBuilding += Time.deltaTime;       
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private Vector3 GetWorldMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        var correctedPos = Camera.main.ScreenToWorldPoint(mousePos);
        correctedPos.z = 0f;

        return correctedPos;
    }



    public void LoadNextLevel()
    {
        LoadLevel(gameLevel+1);
    }


    public void LoadLevel()
    {
        LoadLevel(gameLevel);
    }

    public void LoadLevel(int level)
    {

        levelManager.LoadLevel(level);
    }


    public void StartGame()
    {
        gameState = GameState.Started;
    }

    public void GameOver()
    {
        gameState = GameState.Ended;

    }

}

public enum GameState
{
    Menu, Started, NextLevel, Ended
}

public enum ArrowState
{
    PowerOn, PowerOff, Hidden
}
