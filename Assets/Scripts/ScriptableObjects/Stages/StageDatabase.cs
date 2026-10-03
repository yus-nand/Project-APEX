using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDatabase", menuName = "Game/Stage Database")]
public class StageDatabase : ScriptableObject
{
    [SerializeField] private List<StageData> stages = new();
    public IReadOnlyList<StageData> Stages => stages;
}
