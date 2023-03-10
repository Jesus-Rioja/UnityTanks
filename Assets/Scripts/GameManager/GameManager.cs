using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SetUpGamemode();
    }

    void Update()
    {
        
    }

    private void SetUpGamemode()
    {
        GameObject temp = Instantiate(Tank, Vector3.zero, Quaternion.identity);
        temp.transform.position = TankSpawnPoints[0].position;
        temp.SetActive(true);
        temp.GetComponent<TargetTank>().PlayerIndex = 0;
        CurrentPlayers.Add(temp);

        BindEvents();
    }

    private void BindEvents()
    {
        foreach(GameObject gameObject in CurrentPlayers)
        {
            gameObject?.GetComponent<TargetTank>().OnTankDeath.AddListener(RespawnTank);
        }
    }

    private void RespawnTank(int PlayerIndex)
    {
        CurrentPlayers[PlayerIndex].transform.position = TankSpawnPoints[PlayerIndex].position;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
