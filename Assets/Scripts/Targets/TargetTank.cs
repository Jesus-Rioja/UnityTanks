using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetTank : TargetWithLife
{
    [Header("Tank visuals")]
    [SerializeField] GameObject TankShield;

    [Header("Tank destroyed sound")]
    [SerializeField] AudioSource TankExplosionSound;

    [HideInInspector] public UnityEvent<int> OnTankDeath;
    [HideInInspector] public int PlayerIndex = 0;

    private CharacterController CC;

    private void Awake()
    {
        TankShield.SetActive(false);
        CC = GetComponent<CharacterController>();
    }

    public override void LoseLife()
    {
        base.LoseLife();

        if(CurrentLife <= 1)
        {
            TankShield.SetActive(false);
        }
    }

    protected override void CheckStillAlive()
    {
        if (CurrentLife <= 0 && !bIsDead)
        {
            if(!TankExplosionSound.isPlaying)
            {
                TankExplosionSound.Play();
            }

            bIsDead = true; 
            CC.enabled = false; //Disable character controller to allow GameManager set its transform position

            OnTankDeath.Invoke(PlayerIndex); //Bind to GameManager to set its respawn position
            FullRegenerateLife();
            StartCoroutine(EnableInvulnerabilityOnRespawn()); //Tank is 3 secs invulnerable after respawn
        }
    }

    #region TriggerEffects

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shield")) //Check effector
        {
            CurrentLife = 2;
            TankShield.SetActive(true); //Add shield visuals
            Destroy(other.gameObject);
            GameManager.Instance.GetComponent<EffectorsManager>().EnableTimerToSpawnNewEffector();
        }
    }

    #endregion

    IEnumerator EnableInvulnerabilityOnRespawn()
    {
        bInvulnerable = true;
        CC.enabled = true;
        yield return new WaitForSeconds(2.0f);
        bInvulnerable = false;
        bIsDead = false;
    }

}
