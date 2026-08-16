using UnityEngine;

public class XPGem : MonoBehaviour
{
    [Header("Attraction Settings")]
    [SerializeField] private float initialSpeed = 3f;
    [SerializeField] private float acceleration = 15f;
    private Transform player;
    private PlayerStats stats;
    private bool isAttracted;
    private float currentSpeed;
    private ObjectPool pool;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stats = player.GetComponent<PlayerStats>();
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance <= stats.AttractionRadius)
            isAttracted = true;

        if(isAttracted)
        {
            currentSpeed += acceleration * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.position, currentSpeed * Time.deltaTime);
        }
    }
    private void OnEnable()
    {
        currentSpeed = initialSpeed;
        isAttracted = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerExperience playerXP = other.GetComponent<PlayerExperience>();
        PlayerStats stats = other.GetComponent<PlayerStats>();
        if(playerXP == null)
            return;

        playerXP.AddXP(stats.XP_Reward);
        pool.Return(gameObject);
    }
    public void Initialize(Vector3 position, ObjectPool _pool)
    {
        transform.position = position;
        pool = _pool;
    }
}
