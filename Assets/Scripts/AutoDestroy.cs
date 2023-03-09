using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float TimeToDestroy = 0.1f;

    private void Update()
    {
        TimeToDestroy -= Time.deltaTime;
        if (TimeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
