using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class LevelDataClass
{
    private GameObject _level;
    private Vector3 _intialCubePosition;

    public LevelDataClass(GameObject _level, Vector3 _intialCubePosition)
    {
        this._level = _level;
        this._intialCubePosition = _intialCubePosition;
    }


    public GameObject GetLevel()
    {
        return _level;
    }

    public Vector3 GetInitialCubePosition()
    {
        return _intialCubePosition;
    }

}
