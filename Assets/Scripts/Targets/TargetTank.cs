using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTank : TargetWithLife
{
    [SerializeField] GameObject TankShield;

    private void Awake()
    {
        TankShield.SetActive(false);
    }

    public override void LoseLife()
    {
        base.LoseLife();

        if(CurrentLife <= 1)
        {
            TankShield.SetActive(false);
        }
    }

    #region TriggerEffects

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield")) //Check effector
        {
            CurrentLife = 2;
            TankShield.SetActive(true);
            Destroy(other.gameObject);
            GameManager.Instance.GetComponent<EffectorsManager>().EnableTimerToSpawnNewEffector();
        }
    }

    #endregion
}
