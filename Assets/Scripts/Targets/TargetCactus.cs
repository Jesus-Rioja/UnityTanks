using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCactus : TargetWithLife
{
    Animator CactusAnim;

    private bool bIsDeath = false; //Bool to avoid multiple executions of CheckStillAlive() when cactus have dead -> This can cause to increment multiple cactus deaths instead of once

    private void Awake()
    {
        CactusAnim = GetComponentInChildren<Animator>();
    }

    protected override void CheckStillAlive()
    {
        if (CurrentLife <= 0 && !bIsDeath)
        {
            GameManager.Instance.GetComponent<SingleGamemode>().AddCactusDestroyed();
            CactusAnim.SetTrigger("Death");
            bIsDeath = true;
        }
    }

    public void DestroyCactus()
    {
        Destroy(this.gameObject);
    }
}
