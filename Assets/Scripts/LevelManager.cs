using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private LevelLoader level;


    void Awake()
    {
        level = LevelLoader.loader;
    }
    public void Level1()
    {
        PlayerPrefs.SetInt("SelectedLevel", 0);
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        PlayerPrefs.SetInt("SelectedLevel", 1);
        SceneManager.LoadScene(1);
    }

    public void Level3()
    {
        PlayerPrefs.SetInt("SelectedLevel", 2);
        SceneManager.LoadScene(1);
    }

    public void Level4()
    {
        PlayerPrefs.SetInt("SelectedLevel", 3);
        SceneManager.LoadScene(1);
    }
}
