using UnityEngine;

public class ParticleAutoReturn : MonoBehaviour
{
    private ParticleSystem ps;
    private ObjectPool pool;
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }
    public void Initialize(ObjectPool pool)
    {
        this.pool = pool;
    }
    private void OnEnable()
    {
        ps.Play();
    }
    private void Update()
    {
        if(!ps.IsAlive())
        {
            pool.Return(gameObject);
        }
    }
}
