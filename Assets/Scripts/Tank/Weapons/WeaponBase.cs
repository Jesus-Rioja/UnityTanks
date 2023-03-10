using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public enum WeaponUseType
    {
        TurretTank,
        TurretTankContinuousShot,
        TurretTankMultiShot,
        Undefined,
    };

    public virtual WeaponUseType GetUseType() { return WeaponUseType.Undefined; }

    [HideInInspector] public bool bShotAllowed = true;


    public virtual void Shot()
    {
        
    }
}
