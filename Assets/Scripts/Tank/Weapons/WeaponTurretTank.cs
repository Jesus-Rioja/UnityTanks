using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTurretTank : WeaponBase
{
    [Header("Proyectile data")]
    [SerializeField] GameObject ProyectilPrefab;
    [SerializeField] Transform ShootPoint;
    [SerializeField] float ForceOnShoot = 100.0f;




    public override WeaponUseType GetUseType() { return WeaponUseType.TurretTank; }


    public override void Shot()
    {
        if (bShotAllowed)
        {
            GameObject proyectil = Instantiate(ProyectilPrefab, ShootPoint.position, ShootPoint.rotation);
            proyectil.GetComponent<Rigidbody>()?.AddForce(ShootPoint.forward * ForceOnShoot);

        }
    }

    public override void StartShooting()
    {
        base.StartShooting();
    }

    public override void StopShooting()
    {
        base.StopShooting();
    }
}
