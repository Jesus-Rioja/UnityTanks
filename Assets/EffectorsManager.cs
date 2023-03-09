using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectorsManager : MonoBehaviour
{
    private struct SpawnPointData
    {
        public Vector3 pos;
        public GameObject effector;
    }

    [Header("Effectors info")]
    [SerializeField] GameObject[] EffectorPrefabs; //Multiple effectors available
    [SerializeField] Transform[] SpawnPoints;
    [SerializeField] LayerMask EffectorsLayer;

    private List<SpawnPointData> SpawnPointsData;
    private float TimeToInvokeNewEffector = -0.1f;
    private int EffectorsToSpawn = 4; //Queue of effectors to spawn

    private void Awake()
    {
        SpawnPointsData = new List<SpawnPointData>();
    }

    private void Start()
    {
        FillSpawnPointsList(); //Fills the list with the spawn points available
    }

    private void Update()
    {
        if(EffectorsToSpawn > 0)
        {
            TimeToInvokeNewEffector -= Time.deltaTime;

            if(TimeToInvokeNewEffector <= 0)
            {
                TimeToInvokeNewEffector = 5.0f;
                SpawnEffector();
            }
        }
    }

    private void SpawnEffector()
    {
        int listIndex = Random.Range(0, SpawnPoints.Length);
        SpawnPointData newSpawnPoint = SpawnPointsData[listIndex]; //Get random spawnpoint

        if (newSpawnPoint.effector == null) //Check if this position is available to spawn
        {
            GameObject newEffector = Instantiate(EffectorPrefabs[Random.Range(0, EffectorPrefabs.Length)], SpawnPointsData[listIndex].pos, Quaternion.identity);
            newSpawnPoint.effector = newEffector;
            SpawnPointsData[listIndex] = newSpawnPoint;
            EffectorsToSpawn--;
        }
        else
        {
            SpawnEffector();
        }


        TimeToInvokeNewEffector = 5.0f;
    }

    private void FillSpawnPointsList()
    {
        SpawnPointData temp;
        foreach(Transform transform in SpawnPoints)
        {
            temp.pos = transform.position;
            temp.effector = null;
            SpawnPointsData.Add(temp);
        }
    }

    public void EnableTimerToSpawnNewEffector()
    {
        EffectorsToSpawn++;
    }

}
