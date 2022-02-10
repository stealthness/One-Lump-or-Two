using System;
using UnityEngine;

public class SugarCubeManager : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject sugarCube;
    public CubeState cubeState;
    public UIMenuManager menuManager;

    private bool _flyHit;
    private Vector3 _initCubePos;

    void Start()
    {
        _initCubePos = new Vector3(-5f, -3f, 0f);
        sugarCube.transform.position = _initCubePos;
        _flyHit = false;
        cubeState = CubeState.Ready;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ShootCube(Vector3 force)
    {

        sugarCube.GetComponent<Rigidbody2D>().AddForce(force);
        cubeState = CubeState.Flying;
    }

    internal void ShootCube(object p)
    {
        throw new NotImplementedException();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name.Equals("Inside Cup")){
            gameManager.gameState = GameState.Ended;
            cubeState = CubeState.InCup; 
            Debug.Log("He shoots he scores");
            if (_flyHit)
            {
                Debug.Log("Bonus");
                gameManager.bonusStatus = BonusStatus.Achieved;
            }

            sugarCube.transform.position = _initCubePos;
            menuManager.ActivateCompletedLevelPanel();
        } else if (collision.name.Equals("Fly1")){
            Debug.Log("Swish");
            _flyHit =true;
        } else if (collision.name.Equals("Boundary"))
        {
            gameManager.gameState = GameState.Ended;
            cubeState = CubeState.Missing;
            sugarCube.transform.position = _initCubePos;
        }
    }

    public void ResetPosition()
    {
        this.transform.position = _initCubePos;
    }
}


public enum CubeState
{
    Ready, Flying, InCup, Missing
}

public enum BonusStatus
{
    Available, Failed, Achieved
}
