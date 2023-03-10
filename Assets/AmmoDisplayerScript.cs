using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplayerScript : MonoBehaviour
{
    TMP_Text AmmoDisplay;
    WeaponHandler PlayerWeapon = null;

    private void Start()
    {
        AmmoDisplay = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        if (PlayerWeapon)
        {
            AmmoDisplay.text = "" + PlayerWeapon.GetCurentAmmo();

        }
        else
        {
            FindPlayer();
        }
    }

    private void FindPlayer()
    {
        GameObject player = GameManager.Instance.CurrentPlayers[0];

        if (player)
        {
            PlayerWeapon = player.GetComponentInChildren<WeaponHandler>();
        }
    }
}
