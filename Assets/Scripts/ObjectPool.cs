using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    List<GameObject> PooledObjects;

    [Header("Object Pool info")]
    [SerializeField] GameObject PrefabToPool;
    [SerializeField] int AmountToPool = 30;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject temp;
        for (int i = 0; i < AmountToPool; i++)
        {
            temp = Instantiate(PrefabToPool, Vector3.zero, Quaternion.identity);
            temp.SetActive(false);
            PooledObjects.Add(temp);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < AmountToPool; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        return null;
    }
}
