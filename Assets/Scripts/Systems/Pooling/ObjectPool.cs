using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int intitialSize = 20;

    private readonly Queue<GameObject> pool = new Queue<GameObject>();
    private void Awake()
    {
        for(int i = 0; i < intitialSize; i++)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        if(pool.Count == 0)
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
        GameObject pooledObject = pool.Dequeue();
        pooledObject.SetActive(true);
        return pooledObject;
    }
    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}
