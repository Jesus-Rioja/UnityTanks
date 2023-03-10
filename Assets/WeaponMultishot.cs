using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMultishot : WeaponBase
{
    [Header("Proyectile data")]
    [SerializeField] Transform ShootPoint;
    [SerializeField] float ForceOnShoot = 100.0f;
    [SerializeField] int NumberOfProjectiles = 6;

    public override WeaponUseType GetUseType() { return WeaponUseType.TurretTankMultiShot; }


    public override void Shot()
    {
        if (bShotAllowed)
        {
            for(int i = 0; i < NumberOfProjectiles; i++) //Spawn multiple projectiles
            {
                GameObject projectile = ObjectPool.Instance.GetPooledObject(); //Finds one available bullet from the pool
                if (projectile)
                {
                    //Generate random rotation to apply to projectiles
                    float randomRotation = Random.Range(-60, 60);
                    
                    //Locate and rotate to current position
                    projectile.transform.position = ShootPoint.position;
                    projectile.transform.rotation = ShootPoint.rotation * Quaternion.Euler(0, randomRotation, 0);
                    projectile.SetActive(true);

                    projectile.GetComponent<Rigidbody>()?.AddForce(projectile.transform.forward * ForceOnShoot); //Apply force at random rotation
                }
            }

        }
    }
}
