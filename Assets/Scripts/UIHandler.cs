using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
# if UNITY_EDITOR
using UnityEditor;
# endif

public class UIHandler : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject gameStartPanel;
    [SerializeField] private GameObject gamePausePanel;
    [SerializeField] private GameObject gameOverPanel;

    private bool paused;

    void Start()
    {
        paused = false;
        Time.timeScale = 0;

        MainManager.Instance.LoadScore();

        gameStartPanel.gameObject.SetActive(true);        
        gamePausePanel.gameObject.SetActive(false);        
        gameOverPanel.gameObject.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ChangePause();
        /*
        if (!MainManager.Instance.isGameActive)
            GameIsOver();
            */
    }

    public void StartGame()
    {
        MainManager.Instance.isGameActive = true;
        gameStartPanel.gameObject.SetActive(false);        
        Time.timeScale = 1;
        MainManager.Instance.SaveScore();
    }
    
    public void ChangePause()
    {
        if (MainManager.Instance.isGameActive)
        {
            if(!paused)
            {
                paused = true;
                gamePausePanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                gamePausePanel.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void GameIsOver()
    {
        //MainManager.Instance.SaveScore();
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        MainManager.Instance.SaveScore();

        # if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        # else
        Application.Quit();
        # endif
    }
}