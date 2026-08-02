using UnityEngine;

public class XPGem : MonoBehaviour
{
    [SerializeField] private int xpValue = 1;
    [Header("Attraction Settings")]
    [SerializeField] private float attractionRadius = 2f;
    [SerializeField] private float initialSpeed = 3f;
    [SerializeField] private float acceleration = 15f;

    private Transform player;
    private bool isAttracted;
    private float currentSpeed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance <= attractionRadius)
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

        if(playerXP == null)
            return;

        playerXP.AddXP(xpValue);
        Destroy(gameObject);
    }
}
