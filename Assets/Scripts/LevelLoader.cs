using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelData levelData;  
    public int levelIndex;        // which level to load
    public static LevelLoader loader;
    private Vector3 levelSpawnPos = new Vector3(0,-3.2f,0);

    void Awake()
    {
        loader = this;
    }
    void Start()
    {
        levelIndex = PlayerPrefs.GetInt("SelectedLevel", 0);
        LoadLevel(levelIndex);

    }

    public void LoadLevel(int index)
    {
        if (index < 0 || index >= levelData.levelPrefab.Length)
        {
            Debug.LogError("Invalid level index!");
            return;
        }

        Instantiate(levelData.levelPrefab[index], levelSpawnPos, Quaternion.identity);
    }

    public void LoadNextLevel()
    {
        levelIndex ++;
        LoadLevel(levelIndex);
    }
}
