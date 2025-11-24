using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelData levelData;  
    public int levelIndex;        // which level to load
    private Vector3 levelSpawnPos = new Vector3(4,0,0);
    void Start()
    {
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
