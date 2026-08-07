using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveDatabase", menuName = "Game/Wave Database")]
public class WaveDatabase : ScriptableObject
{
    [SerializeField] private List<WaveData> waves = new();
    public IReadOnlyList<WaveData> Waves => waves;
}
