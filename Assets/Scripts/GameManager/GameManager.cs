using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


//Singleton
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public List<GameObject> CurrentPlayers = new List<GameObject>();

    [Header("Tank info")]
    [SerializeField] Transform[] TankSpawnPoints;
    [SerializeField] GameObject Tank; //Prefab controller

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        GetComponent<MapGenerator>().GenerateMap();
        SetUpGamemode(); //Initialize game and scripts
    }

    private void SetUpGamemode() //Check the game mode -> Single or 2 players
    {
        int gameModeSelected = GamemodeSelector.Gamemode;

        bool SingleGameModeSelected = (gameModeSelected == 1);

        if (gameModeSelected < 1 || gameModeSelected > 2) //If there is no gamemode, return to menu
        {
            SceneManager.LoadScene("MainMenu");
        }

        for (int i = 0; i < gameModeSelected; i++) //Spawn the tanks
        {
            GameObject temp = Instantiate(Tank, Vector3.zero, Quaternion.identity);
            temp.transform.position = TankSpawnPoints[i].position;
            temp.SetActive(true);
            temp.GetComponent<TargetTank>().PlayerIndex = i;
            CurrentPlayers.Add(temp);
        }

        BindEvents();

        //Enables the Single or 2 Players gamemode script
        GetComponent<SingleGamemode>().enabled = SingleGameModeSelected ? true : false;
        GetComponent<TwoPlayersGamemode>().enabled = !SingleGameModeSelected ? true : false;

    }

    private void BindEvents()
    {
        foreach(GameObject gameObject in CurrentPlayers)
        {
            gameObject?.GetComponent<TargetTank>().OnTankDeath.AddListener(RespawnTank);
        }
    }

    private void RespawnTank(int PlayerIndex) //Return tank to its spawn position
    {
        CurrentPlayers[PlayerIndex].transform.position = TankSpawnPoints[PlayerIndex].position;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
