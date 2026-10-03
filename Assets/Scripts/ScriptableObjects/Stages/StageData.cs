using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Game/Stage Data")]
public class StageData : ScriptableObject
{
    [Header("Identity")]
    public string id;
    public string stageName;
    [Header("Waves")]
    public WaveDatabase waveDatabase;
    [Header("Rewards")]
    public int currencyReward = 50;
    [Header("Progression")]
    public StageData nextStage;
}
