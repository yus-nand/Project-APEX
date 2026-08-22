using UnityEngine;
using DG.Tweening;

public class XPGem : MonoBehaviour
{
    [Header("Attraction Settings")]
    [SerializeField] private float initialSpeed = 3f;
    [SerializeField] private float acceleration = 15f;
    [Header("Animaton Settings")]
    [SerializeField] private float collectAnimationDuration = 0.12f;
    [SerializeField] private float collectScale = 0.4f;
    private Transform player;
    private PlayerStats stats;
    private bool isAttracted;
    private bool isCollecting;
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
        transform.localScale = Vector3.one * 0.7f;
        isAttracted = false;
        isCollecting = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isCollecting)
            return;
        
        PlayerExperience playerXP = other.GetComponent<PlayerExperience>();
        PlayerStats stats = other.GetComponent<PlayerStats>();
        if(playerXP == null)
            return;
        isCollecting = true;
        playerXP.AddXP(stats.XP_Reward);
        PlayCollectEffect();
    }
    public void Initialize(Vector3 position, ObjectPool _pool)
    {
        transform.position = position;
        pool = _pool;
    }
    private void PlayCollectEffect()
    {
        transform.DOScale(Vector3.one * collectScale, collectAnimationDuration).SetEase(Ease.OutQuad).OnComplete(() => 
        {
            pool.Return(gameObject);
        }
        );
    }
}
