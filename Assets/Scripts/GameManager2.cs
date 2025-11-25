using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletePannel;
    
    public static GameManager2 manager;

    void Awake()
    {
        manager = this;
    }
    public void OnLevelCompleted()
    {
        levelCompletePannel.gameObject.SetActive(true);
    }

}
