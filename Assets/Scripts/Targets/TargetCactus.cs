using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCactus : TargetWithLife
{
    Animator CactusAnim;

    private void Awake()
    {
        CactusAnim = GetComponentInChildren<Animator>();
    }

    protected override void CheckStillAlive()
    {
        if (CurrentLife <= 0 && !bIsDead)
        {
            GameManager.Instance.GetComponent<SingleGamemode>().AddCactusDestroyed();
            CactusAnim.SetTrigger("Death");
            bIsDead = true;
        }
    }

    public void DestroyCactus()
    {
        Destroy(this.gameObject);
    }
}
