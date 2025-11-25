using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject levelPannel;


    public void StartGame()
    {
        startButton.gameObject.SetActive(false);
        levelPannel.gameObject.SetActive(true);
        // SceneManager.LoadScene(1);

    }

}
