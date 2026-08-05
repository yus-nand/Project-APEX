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
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerExperience playerXP = other.GetComponent<PlayerExperience>();
        PlayerStats stats = other.GetComponent<PlayerStats>();
        if(playerXP == null)
            return;

        playerXP.AddXP(stats.XP_Reward);
        Destroy(gameObject);
    }
}
