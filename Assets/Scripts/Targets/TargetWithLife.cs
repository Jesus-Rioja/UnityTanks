using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWithLife : MonoBehaviour
{
    [Header("Life info")]
    [SerializeField] const float MaxLife = 1.0f;
    [SerializeField] float OnHitLifeLost = 1.0f;

    protected bool bInvulnerable = false;
    protected bool bIsDead = false; //Bool to avoid multiple executions of CheckStillAlive() when target have dead -> This can cause to increment multiple target deaths instead of once
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
        if(CurrentLife <= 0 && !bIsDead)
        {
            Destroy(gameObject); 
            bIsDead = true;
        }
    }

    protected void FullRegenerateLife()
    {
        CurrentLife = MaxLife;
    }
}
