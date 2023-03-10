using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTurretTank : WeaponBase
{
    [Header("Proyectile data")]
    [SerializeField] Transform ShootPoint;
    [SerializeField] float ForceOnShoot = 100.0f;


    public override WeaponUseType GetUseType() { return WeaponUseType.TurretTank; }


    public override void Shot()
    {
        if (bShotAllowed)
        {
            GameObject projectile = ObjectPool.Instance.GetPooledObject(); //Finds one available bullet from the pool
            if (projectile)
            {
                //Locate and rotate to current position
                projectile.transform.position = ShootPoint.position;
                projectile.transform.rotation = ShootPoint.rotation;
                projectile.SetActive(true);

                projectile.GetComponent<Rigidbody>()?.AddForce(ShootPoint.forward * ForceOnShoot); //Apply force
            }

        }
    }

}
