using System.Collections.Generic;
using UnityEngine;
public enum EnemyType
{
    Normal,
    Runner,
    Tank,
    Dasher,
    Ranged,
    Splitter
}
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]  
public class EnemyData : ScriptableObject
{
    [Header("General")]
    public string enemyName;
    public EnemyType type;
    // public EnemyType enemyType
    [Header("Prefab")]
    public GameObject prefab;
    [Header("Drops")]
    [SerializeField]private List<PickupDropInfo> dropTable = new();
    public IReadOnlyList<PickupDropInfo> DropTable => dropTable;
    [Header("Stats")]
    public int maxHealth = 10;
    public float moveSpeed = 3f;
    public int contactDamage = 2;
    public int xpGemCount = 1;
    public float recoveryDuration = 1f;
    [Header("Tank")]
    public int lastResortHealthValue = 8;
    [Header("Dash")]
    // public bool isDasher;
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    [Header("Ranged")]
    // public bool isRanged;
    public float preferredRange = 6f;
    public int projectileDamage = 1;
    public float projectileSpeedMultiplier = 1f;
    [Header("Splitter")]
    // public bool canSplit;
    public EnemyData splitChildData;
    public int splitChildCount = 2;
}
