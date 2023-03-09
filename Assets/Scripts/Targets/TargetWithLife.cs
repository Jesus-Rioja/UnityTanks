using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWithLife : MonoBehaviour
{
    [Header("Life info")]
    [SerializeField] const float MaxLife = 1.0f;
    [SerializeField] float OnHitLifeLost = 1.0f;

    bool bInvulnerable = false;
    protected float CurrentLife;


    void Start()
    {
        CurrentLife = MaxLife;
    }

    public virtual void LoseLife()
    {
        if(!bInvulnerable)
        {
            CurrentLife -= OnHitLifeLost;
            CheckStillAlive();
        }
    }

    protected virtual void CheckStillAlive()
    {
        if(CurrentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
