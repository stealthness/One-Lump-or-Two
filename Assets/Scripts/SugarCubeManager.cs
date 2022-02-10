using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCubeManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject sugarCube;
    public CubeState cubeState;


    void Start()
    {
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
        Debug.Log("He shoots he scores");
        gameManager.gameState = GameState.Ended;
        cubeState = CubeState.InCup;
    }
}


public enum CubeState
{
    Ready, Flying, InCup, Missing
}
