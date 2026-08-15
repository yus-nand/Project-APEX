using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]  
public class EnemyData : ScriptableObject
{
    [Header("General")]
    public string enemyName;
    [Header("Prefab")]
    public GameObject prefab;
    [Header("Stats")]
    public float maxHealth = 10f;
    public float moveSpeed = 3f;
    public float contactDamage = 2f;
    public float xpReward = 1;
}
