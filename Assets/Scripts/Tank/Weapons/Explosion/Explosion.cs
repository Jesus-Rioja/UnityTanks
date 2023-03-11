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
        List<TargetWithLife> AlreadyHittedTarget = new List<TargetWithLife>();

        foreach (Collider c in colliders) //Finds for hittable targets
        {
            TargetWithLife HittedTarget = c.GetComponent<TargetWithLife>();
            if(!AlreadyHittedTarget.Contains(HittedTarget))
            {
                HittedTarget?.LoseLife(); //If hittable, damage it
                AlreadyHittedTarget.Add(HittedTarget);
            }


        }

        Instantiate(prefabVisualExplosion, transform.position, Quaternion.identity); //Instantiate visuals
    }
}
