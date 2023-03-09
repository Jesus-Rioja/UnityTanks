using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject prefabVisualExplosion;
    [SerializeField] float radius = 1;


    void Start()
    {
        Destroy(gameObject);


        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider c in colliders)
        {
            TargetWithLife HittedTarget = c.GetComponent<TargetWithLife>();
            HittedTarget?.LoseLife();
        }

        Instantiate(prefabVisualExplosion, transform.position, Quaternion.identity);
    }
}
