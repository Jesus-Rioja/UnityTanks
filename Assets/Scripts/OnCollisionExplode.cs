using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionExplode : MonoBehaviour
{
    [SerializeField] GameObject[] OnExplosionPrefabs;
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);

        foreach (GameObject prefab in OnExplosionPrefabs)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }

    private void OnEnable()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void OnDisable()
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}