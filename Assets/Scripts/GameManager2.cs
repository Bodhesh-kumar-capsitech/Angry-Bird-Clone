using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletePannel;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private GameObject gameOverPannel;


    private GameObject[] enemies;
    
    public static GameManager2 manager;
    private bool isLevelCompleted = false;
    private bool isPaused = false;
    private bool isGameOver = false;



    void Awake()
    {
        manager = this;
    }
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        print("Enemy length is: " + enemies.Length);

        if(enemies.Length == 0)
        {
            OnLevelCompleted();
        }
        else
        {
            isLevelCompleted = false;
        }

        if(isLevelCompleted == true || isPaused == true || isGameOver == true) 
        {
           Time.timeScale = 0;   
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void OnLevelCompleted()
    {
        isLevelCompleted = true;
        levelCompletePannel.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        gameOverPannel.gameObject.SetActive(false);
    }

    public void OnReplay()
    {
        int lastLevelIndex = PlayerPrefs.GetInt("SelectedLevel");
        LevelLoader.loader.levelIndex = lastLevelIndex;
        SceneManager.LoadScene(1);
        levelCompletePannel.gameObject.SetActive(false);
        gameOverPannel.gameObject.SetActive(false);

    }

    public void OnNext()
    {
       int currLevelIndex = PlayerPrefs.GetInt("SelectedLevel") + 1;
       PlayerPrefs.SetInt("SelectedLevel",currLevelIndex);
    //    LevelLoader.loader.levelIndex = currLevelIndex;
       SceneManager.LoadScene(1);
       levelCompletePannel.gameObject.SetActive(false);
        gameOverPannel.gameObject.SetActive(false);

    }

    public void OnHome()
    {
        SceneManager.LoadScene(0);
        gameOverPannel.gameObject.SetActive(false);

    }

    public void OnPause()
    {
        isPaused = true;
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
        replayButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        gameOverPannel.gameObject.SetActive(false);
    }

    public void OnPlay()
    {
        isPaused = false;
        pauseButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        gameOverPannel.gameObject.SetActive(false);
    }

    public void OnExit()
    {
        #if UNITY_EDITOR
            // Stops play mode in the Unity Editor
            EditorApplication.isPlaying = false;
        #else
            // Quits the game application
            Application.Quit();
        #endif        
    }

    public void OnGameOver()
    {
        isGameOver = true;
        gameOverPannel.gameObject.SetActive(true);
    }

}
