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

    private bool paused;

    /*
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] public TextMeshProUGUI bestWaveText; // we will access it on SpawnManager.cs
    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI bestPointText;
    [SerializeField] private TextMeshProUGUI powerupText;
    */

    void Start()
    {
        paused = false;
        Time.timeScale = 0;

        //MainManager.Instance.LoadScore();
        //MainManager.Instance.isGameActive = true;

        gameStartPanel.gameObject.SetActive(true);        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ChangePause();
    }
    
    public void ChangePause()
    {
        if (true)//MainManager.Instance.isGameActive)
        {
            if(!paused)
            {
                paused = true;
                //pausePanel.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                paused = false;
                //pausePanel.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void GameIsOver()
    {
        //MainManager.Instance.SaveScore();
        gameStartPanel.gameObject.SetActive(true);
        //MainManager.Instance.isGameActive = false;

        /*
        if (point > MainManager.Instance.bestPoint)
        {
            MainManager.Instance.bestPoint = point;
            bestPointText.SetText("Best Point: " + MainManager.Instance.bestPoint);
        }
        */
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        //MainManager.Instance.SaveScore();

        # if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        # else
        Application.Quit();
        # endif
    }
}