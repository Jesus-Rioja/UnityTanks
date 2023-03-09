using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCactus : TargetWithLife
{
    protected override void CheckStillAlive()
    {
        if (CurrentLife <= 0)
        {
            GameManager.Instance.GetComponent<SingleGamemode>().AddCactusDestroyed();
            Destroy(gameObject);
        }
    }
}
