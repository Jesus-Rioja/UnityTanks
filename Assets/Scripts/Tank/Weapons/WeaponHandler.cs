using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private WeaponBase[] Weapons;
    private WeaponBase CurrentWeapon;
    private bool bCanShoot = false;

    //Shoot cadence
    [Header("Shoot cadence")]
    [SerializeField] float ShotsPerSecond = 0.5f;
    [Header("Ammo info")]
    [SerializeField] int CurrentAmmo = 10;
    [SerializeField] int TotalAmmo = 15;

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
            if(weapon.GetUseType() == WeaponBase.WeaponUseType.TurretTank)
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
        if (Time.time > TimeToAllowShoot)
        {
            bCanShoot = true; 
        }
    }

    public void UseWeapon() 
    {
        if(bCanShoot && CurrentAmmo >= 1)
        {
            ShootSound.Play();
            CurrentWeapon.Shot();
            CurrentAmmo--;
            TimeToAllowShoot = Time.time + 1.0f / ShotsPerSecond;
            bCanShoot = false;
        }
        else
        {
            RechargingSound.Play();
        }
    }
}
