using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour
{

    private readonly float _titleMoveEnter = 100f;
    private readonly float _titleMoveExit = -800f;
    private readonly float _rightButtonMoveEnter = 900f;
    private readonly float _rightButtonMoveExit = 1400f;
    private readonly float _rightButtonHalfMove = 1200f;
    private readonly float _optionsPanelMoveEnter = 250f;
    private readonly float _optionsPanelMoveExit = -400f;
    private readonly float _timeToEaseInInSecs = 1.5f;

    public GameManager gameManager;
    public AudioManager audioManager;

    public GameObject menuPanel;
    public GameObject optionsPanel;
    public GameObject completedLevelPanel;

    public GameObject titleBar;
    public GameObject startButton;
    public GameObject optionsButton;

    public Toggle musicToggle;


    // Start is called before the first frame update
    void Start()
    {
        completedLevelPanel.SetActive(false);
        LeanTween.moveX(titleBar, _titleMoveEnter, _timeToEaseInInSecs);
        LeanTween.moveX(startButton, _rightButtonMoveEnter, _timeToEaseInInSecs);
        LeanTween.moveX(optionsButton, _rightButtonMoveEnter, _timeToEaseInInSecs);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ClearMenu()
    {
        LeanTween.moveX(titleBar, _titleMoveExit, _timeToEaseInInSecs);
        LeanTween.moveX(startButton, _rightButtonMoveExit, _timeToEaseInInSecs);
        LeanTween.moveX(optionsButton, _rightButtonMoveExit, _timeToEaseInInSecs);
    }




    public void OnOptionsButtonSelect()
    {
        optionsPanel.SetActive(true);
        LeanTween.moveX(optionsPanel, _optionsPanelMoveEnter, _timeToEaseInInSecs);
        LeanTween.moveX(startButton, _rightButtonHalfMove, _timeToEaseInInSecs/2);
        LeanTween.moveX(optionsButton, _rightButtonHalfMove, _timeToEaseInInSecs/2); 
    }

    public void OnOptionsPanelOKButtonSelect()
    {

        LeanTween.moveX(optionsPanel, _optionsPanelMoveExit, _timeToEaseInInSecs);
        LeanTween.moveX(startButton, _rightButtonMoveEnter, _timeToEaseInInSecs/2);
        LeanTween.moveX(optionsButton, _rightButtonMoveEnter, _timeToEaseInInSecs/2);
    }


    public void OnStartGameButton()
    {
        ClearMenu();
        gameManager.StartGame();
    }

    public void OnClickNextLevelButton()
    {
        completedLevelPanel.SetActive(false);
        gameManager.LoadNextLevel();
    }

    public void OnClickReplayLevelButton()
    {
        
        completedLevelPanel.SetActive(false);
        gameManager.LoadLevel();
    }

    public void ActivateCompletedLevelPanel()
    {
        completedLevelPanel.SetActive(true);
        LeanTween.scale(completedLevelPanel, new Vector3(0.6f, 0.6f, 1f), 0.5f);
    }

}
