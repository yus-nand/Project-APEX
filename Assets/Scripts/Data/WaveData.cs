using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Game/Wave")]
public class WaveData : ScriptableObject
{
    [Header("Wave Info")]
    public float duration = 60f;
    [Header("Spawning")]
    public int enemyCount = 20;
    public float spawnInterval = 2f;
    [Header("Enemy")]
    public GameObject enemyPrefab;
}
