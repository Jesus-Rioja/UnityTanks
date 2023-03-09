using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExplode : MonoBehaviour
{
    [SerializeField] GameObject[] OnExplosionPrefabs;
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        foreach (GameObject prefab in OnExplosionPrefabs)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }

}