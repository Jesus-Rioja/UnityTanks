using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoDisplayerScript : MonoBehaviour
{
    [Header("Player ID (0 or 1)")]
    [SerializeField] int PlayerIndex = 0;

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
            FindPlayer(); //Find the weapond hanlder to check its bullets
        }
    }

    private void FindPlayer()
    {
        if(GameManager.Instance.CurrentPlayers.Count <= PlayerIndex)
        {
            return;
        }

        GameObject player = GameManager.Instance.CurrentPlayers[PlayerIndex];

        if (player)
        {
            PlayerWeapon = player.GetComponentInChildren<WeaponHandler>();
        }
    }
}
