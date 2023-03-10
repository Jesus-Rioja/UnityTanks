using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoPlayersGamemode : MonoBehaviour
{
    [Header("Gamemode overlay")]
    [SerializeField] GameObject TwoPlayersPlayerOverlay;

    private int[] TankLifeArray;

    public UnityEvent GameFinished;

    private void OnEnable()
    {
        TwoPlayersPlayerOverlay.SetActive(true);
        BindEvents();
    }

    private void Awake()
    {
        TankLifeArray = new int[2] { 0, 0 };
    }

    private void BindEvents()
    {
        foreach (GameObject gameObject in GameManager.Instance.CurrentPlayers)
        {
            gameObject?.GetComponent<TargetTank>().OnTankDeath.AddListener(TankDestroyed);
        }
    }

    private void TankDestroyed(int index) //Everytime a tank dies, increment its lifes counter
    {
        TankLifeArray[index]++;
        CheckTankLifes();
    }

    private void CheckTankLifes()
    {
        for(int i = 0; i < TankLifeArray.Length; i++)
        {
            if (TankLifeArray[i] >= 3)
            {
                Debug.Log("Game finished");
                break;
            }
        }
    }
}
