using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelDatabase", menuName = "Game/LevelDatabase")]
public class LevelDatabase : ScriptableObject
{
    [SerializeField] private List<LevelData> levels = new();
    public LevelData GetLevelData(int level)
    {
        return levels[level - 1];
    }
}
[System.Serializable]
public class LevelData
{
    public int level;
    public int xpRequired;
}
