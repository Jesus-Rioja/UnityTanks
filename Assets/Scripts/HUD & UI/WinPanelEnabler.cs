using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinPanelEnabler : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;

    private void Start()
    {
        WinPanel.SetActive(false);

        GameManager.Instance.GetComponent<SingleGamemode>().GameFinished.AddListener(EnableWinPanel); //Panel activation when 20 cactus destroyed

    }

    private void EnableWinPanel()
    {
        Time.timeScale = 0.0f;
        WinPanel.SetActive(true);
    }
}
