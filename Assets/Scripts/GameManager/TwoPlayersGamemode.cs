using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TwoPlayersGamemode : MonoBehaviour
{
    [Header("Gamemode overlay")]
    [SerializeField] GameObject TwoPlayersPlayerOverlay;

    [Header("Tanks colours")]
    [SerializeField] Color[] TankColours;

    private int[] TankLifeArray;

    [HideInInspector] public UnityEvent<int> GameFinished;
    [HideInInspector] public UnityEvent<int, int> OnTankDestroyed;

    private void OnEnable()
    {
        TwoPlayersPlayerOverlay.SetActive(true);
        BindEvents();
        ApplyMaterials();
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

    private void TankDestroyed(int index) //Everytime a tank dies, increment its kills counter
    {
        TankLifeArray[index]++;
        OnTankDestroyed.Invoke(TankLifeArray[index], index);
        CheckTankLifes();
    }

    private void CheckTankLifes()
    {
        for(int i = 0; i < TankLifeArray.Length; i++) //Check if a tank have died 3 or more times...
        {
            if (TankLifeArray[i] >= 3) //...If so...
            {
                EndGame(i); //...Game finished
                break;
            }
        }
    }

    private void EndGame(int Loser)
    {
        int winner = 0;

        if(TankLifeArray[0] == TankLifeArray[1])
        {
            winner = 2;
        }
        else if(Loser == 0)
        {
            winner = 1;
        }
        else
        {
            winner = 0;
        }

        GameFinished.Invoke(winner + 1);
    }

    private void ApplyMaterials()
    {
        GameObject tmp;

        for(int i = 0; i < GameManager.Instance.CurrentPlayers.Count; i++)
        {
            tmp = GameManager.Instance.CurrentPlayers[i];
            foreach (MeshRenderer meshRenderer in tmp.gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                meshRenderer.materials[0].color = TankColours[i];
            }
        }
    }
}
