using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SingleGamemode : MonoBehaviour
{
    [SerializeField] GameObject CactusPrefab; //Destructible cactus
    [Header("Cactus spawnable area")]
    [SerializeField] Vector2 TopRightPosition;
    [SerializeField] Vector2 BottomLeftPosition;
    [SerializeField] LayerMask BuildingsLayer;

    private int CactusDestroyed = 0;
    private int CactusSpawned = 0;
    private float TimeToInvokeNewCactus;

    public UnityEvent<int> OnCactusDestroyed;
    public UnityEvent GameFinished;

    void Update()
    {
        if(CactusSpawned < 5) //Spawn new cactus if there are less than 5
        {
            TimeToInvokeNewCactus -= Time.deltaTime;

            if (TimeToInvokeNewCactus <= 0)
            {
                SpawnCactus();
            }
        }
    }

    public void AddCactusDestroyed() 
    {
        CactusDestroyed++;
        CactusSpawned--;

        OnCactusDestroyed.Invoke(CactusDestroyed);

        if(CactusDestroyed >= 4) //Ends game when 20 cactus destroyed
        {
            GameFinished.Invoke();
        }

    }

    private void SpawnCactus()
    {
        //Finds random position
        Vector3 SpawnPosition = new Vector3(Random.Range(TopRightPosition.x, BottomLeftPosition.x), 0, Random.Range(TopRightPosition.y, BottomLeftPosition.y));

        RaycastHit outhit;
        //Check if area is free
        bool bAreaIsFree = Physics.SphereCast(SpawnPosition, 2, Vector3.zero, out outhit,BuildingsLayer);

        if(!bAreaIsFree) //Spawns new cactus
        {
            GameObject.Instantiate(CactusPrefab, SpawnPosition, Quaternion.identity);
            CactusSpawned++;
        }
        else //If area not free, finds for another position
        {
            SpawnCactus();
        }


        TimeToInvokeNewCactus = Random.Range(5.0f, 10.0f); //Randomize time to spawn new cactus
    }
}
