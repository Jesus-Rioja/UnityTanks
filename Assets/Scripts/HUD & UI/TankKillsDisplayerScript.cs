using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TankKillsDisplayerScript : MonoBehaviour
{
    [SerializeField] TMP_Text[] KillsDisplayers;

    private void Start()
    {
        GameManager.Instance.GetComponent<TwoPlayersGamemode>().OnTankDestroyed.AddListener(DisplayTankKills);
        DisplayTankKills(0, 0);
        DisplayTankKills(0, 1);
    }

    void DisplayTankKills(int KillsCount, int index)
    {
        KillsDisplayers[index].text = "" + KillsCount;
    }
}
