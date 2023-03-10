using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwoPlayersWinPanelEnabler : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    private void Start()
    {
        WinPanel.SetActive(false);

        GameManager.Instance.GetComponent<TwoPlayersGamemode>().GameFinished.AddListener(EnableWinPanel);

    }

    private void EnableWinPanel(int Winner)
    {
        TMP_Text winText = WinPanel.GetComponentInChildren<TMP_Text>();

        winText.text = "PLAYER " + Winner + " WINS";

        if (Winner == 1)
        {
            winText.color = Color.red;
        }
        else
        {
            winText.color = Color.blue;
        }

        WinPanel.SetActive(true);
    }
}
