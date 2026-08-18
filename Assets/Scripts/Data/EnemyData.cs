using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]  
public class EnemyData : ScriptableObject
{
    [Header("General")]
    public string enemyName;
    [Header("Prefab")]
    public GameObject prefab;
    [Header("Stats")]
    public int maxHealth = 10;
    public float moveSpeed = 3f;
    public int contactDamage = 2;
    public int xpGemCount = 1;
    public float recoveryDuration = 1f;
}
