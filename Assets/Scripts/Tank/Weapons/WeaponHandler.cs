using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private WeaponBase[] Weapons; //Array of available weapons. when modifier taken, current weapon may change to another type
    private WeaponBase CurrentWeapon;
    private bool bCanShoot = false;
    private bool bWithModifier = false;
    private float WeaponModifierDuration = 8.0f;

    //Shoot cadence
    [Header("Shoot cadence")]
    [SerializeField] float ShotsPerSecond = 0.5f;
    [Header("Ammo info")]
    [SerializeField] int CurrentAmmo = 10;
    [SerializeField] int TotalAmmo = 15;

    [Header("Ammo packs")]
    [SerializeField] int OnPackAmmoToRecharge = 5;

    [Header("Audio clips")]
    [SerializeField] AudioSource ShootSound; //Sound played when turret shoots
    [SerializeField] AudioSource RechargingSound; //Sound played when turret cannot shoots

    private void Awake()
    {
        Weapons = GetComponentsInChildren<WeaponBase>();
    }

    void Start()
    {
        foreach(WeaponBase weapon in Weapons)
        {
            if(weapon.GetUseType() == WeaponBase.WeaponUseType.TurretTank) //Finds for the initial weapon
            {
                weapon.enabled = true;
                CurrentWeapon = weapon;
            }
            else
            {
                weapon.enabled = false;
            }
        }
    }

    float TimeToAllowShoot = 2.0f;
    private void Update()
    {
        if (Time.time > TimeToAllowShoot) //When timer ends, allow to shoot again
        {
            bCanShoot = true; 
        }

        if(bWithModifier)
        {
            WeaponModifierDuration -= Time.deltaTime;

            if(WeaponModifierDuration <= 0)
            {
                CurrentWeapon = Weapons[0];
            }
        }

    }

    public void UseWeapon() 
    {
        if(bCanShoot && CurrentAmmo >= 1)
        {
            ShootSound.Play();
            CurrentWeapon.Shot();
            CurrentAmmo--;
            TimeToAllowShoot = Time.time + 1.0f / ShotsPerSecond; //Reset timer
            bCanShoot = false;
        }
        else
        {
            if(!RechargingSound.isPlaying)
            {
                RechargingSound.Play();
            }
        }
    }

    public int GetCurentAmmo() { return CurrentAmmo; }

    #region TriggerEffects

    public void OnEffectorAddAmmo() //Gives ammo when effector picked up
    {
        if (CurrentAmmo + OnPackAmmoToRecharge <= TotalAmmo) //New total ammo cannot be greater then max ammo
        {
            CurrentAmmo += OnPackAmmoToRecharge;
        }
        else
        {
            CurrentAmmo = TotalAmmo;
        }
    }

    public void OnEffectorMultishotWeapon() //Gives multishoot for 8 secs
    {
        bWithModifier = true;
        WeaponModifierDuration = 8.0f;
        CurrentWeapon = Weapons[1]; //Change weapon to multishot one
    }

    #endregion
}
