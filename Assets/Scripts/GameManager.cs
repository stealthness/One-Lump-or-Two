using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private readonly float _increaseFactor = 1.1f;
    private readonly float _thrust = 50f;

    public SugarCubeManager cubeManager;
    public UIMenuManager menuManager;

    public GameObject cube;
    public GameObject arrow;
    public GameObject insideCup;


    float startPowerBuilding;

    public GameState gameState;
    private ArrowState _arrowState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Menu;

        arrow.transform.position = cube.transform.position;
        _arrowState = ArrowState.PowerOff;
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
   
        float angle =((direction.x < 0 )? 180 : 0)+ Mathf.Rad2Deg * Mathf.Atan(direction.y / direction.x);
        arrow.transform.position = cube.transform.position;
        arrow.transform.rotation = Quaternion.Euler(0, 0, angle);


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
