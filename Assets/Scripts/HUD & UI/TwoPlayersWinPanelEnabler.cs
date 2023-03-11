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

        GameManager.Instance.GetComponent<TwoPlayersGamemode>().GameFinished.AddListener(EnableWinPanel); //Panel activation when a player dies 3 times

    }

    private void EnableWinPanel(int Winner)
    {
        Time.timeScale = 0.0f;

        TMP_Text winText = WinPanel.GetComponentInChildren<TMP_Text>();

        winText.text = "PLAYER " + Winner + " WINS!";

        if (Winner == 1)
        {
            winText.color = Color.red;
        }
        else if(Winner == 2)
        {
            winText.color = Color.blue;
        }
        else
        {
            winText.color = Color.green;
            winText.text = "DRAW!";
        }

        WinPanel.SetActive(true);
    }
}
