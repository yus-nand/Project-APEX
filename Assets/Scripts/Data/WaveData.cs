using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Game/Wave")]
public class WaveData : ScriptableObject
{
    [Header("Wave Info")]
    public float duration = 60f;
    [Header("Spawning")]
    public float spawnInterval = 2f;
    [Header("Enemies")]
    public List<EnemySpawnInfo> spawnInfos = new();
}
