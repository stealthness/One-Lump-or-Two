using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool musicOn;


    void Start()
    {
        PlayerPrefs.GetInt("MusicOn");
    }
}
