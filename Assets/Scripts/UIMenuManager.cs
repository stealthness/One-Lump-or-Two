using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMenuManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ClearMenu()
    {
        menuPanel.gameObject.SetActive(false);
    }

    public void OnStartGameButton()
    {
        ClearMenu();
        gameManager.StartGame();
    }

}
