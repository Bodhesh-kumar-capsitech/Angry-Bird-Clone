using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "AngryBirds/Level")]
public class LevelData : ScriptableObject
{
    public GameObject[] levelPrefab;
}
