using UnityEngine;

public class UIMenuManager : MonoBehaviour
{

    private readonly float _titleMove = 100f;
    private readonly float _startMove = 900f;
    //private readonly float _halfMove = 400f;
    private readonly float _timeToEaseInInSecs = 1.5f;

    public GameManager gameManager;
    public GameObject menuPanel;
    public GameObject titleBar;
    public GameObject startButton;
    public GameObject optionsButton;
    public GameObject completeLevel;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveX(titleBar, _titleMove, _timeToEaseInInSecs);
        LeanTween.moveX(startButton, _startMove, _timeToEaseInInSecs);
        LeanTween.moveX(optionsButton, _startMove, _timeToEaseInInSecs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void ClearMenu()
    {
        LeanTween.moveX(titleBar, -800f, _timeToEaseInInSecs);
        LeanTween.moveX(startButton, 1400f, _timeToEaseInInSecs);
        LeanTween.moveX(optionsButton, 1400f, _timeToEaseInInSecs);
        Invoke("DeactivetMenu", _timeToEaseInInSecs +3f);
    }

    private void DeactivetMenu()
    {
        menuPanel.gameObject.SetActive(false);
    }


    public void OnOptionsButtonSelect()
    {
        LeanTween.moveX(startButton, 1100f, _timeToEaseInInSecs/2);
        LeanTween.moveX(optionsButton, 1100f, _timeToEaseInInSecs/2);
    }


    public void OnStartGameButton()
    {
        ClearMenu();
        gameManager.StartGame();
    }

    public void CompleteLevel()
    {
        completeLevel.SetActive(true);
        LeanTween.scale(completeLevel, new Vector3(0.6f, 0.6f, 1f), 0.5f);
    }

}
