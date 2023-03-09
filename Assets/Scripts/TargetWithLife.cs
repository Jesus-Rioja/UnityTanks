using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWithLife : MonoBehaviour
{
    [Header("Life info")]
    [SerializeField] float MaxLife = 1.0f;
    [SerializeField] float OnHitLifeLost = 1.0f;

    bool bInvulnerable = false;
    float CurrentLife;


    void Start()
    {
        CurrentLife = MaxLife;
    }

    public void LoseLife()
    {
        if(!bInvulnerable)
        {
            CurrentLife -= OnHitLifeLost;
            CheckStillAlive();
        }
    }

    private void CheckStillAlive()
    {
        if(CurrentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
