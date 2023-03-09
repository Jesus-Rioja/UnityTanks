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

        foreach (Collider c in colliders) //Finds for hittable targets
        {
            TargetWithLife HittedTarget = c.GetComponent<TargetWithLife>();
            HittedTarget?.LoseLife(); //If hittable, damage it
        }

        Instantiate(prefabVisualExplosion, transform.position, Quaternion.identity); //Instantiate visuals
    }
}
