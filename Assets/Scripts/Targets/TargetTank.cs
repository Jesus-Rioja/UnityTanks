using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTank : TargetWithLife
{
    #region TriggerEffects

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield")) //Check effector
        {
            CurrentLife = 2;
            Destroy(other.gameObject);
            GameManager.Instance.GetComponent<EffectorsManager>().EnableTimerToSpawnNewEffector();
        }
    }

    #endregion
}
