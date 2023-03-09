using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Update()
    {
        if(CactusSpawned < 5)
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
    }

    private void SpawnCactus()
    {
        Vector3 SpawnPosition = new Vector3(Random.Range(TopRightPosition.x, BottomLeftPosition.x), 0, Random.Range(TopRightPosition.y, BottomLeftPosition.y));

        RaycastHit outhit;
        bool bAreaIsFree = Physics.SphereCast(SpawnPosition, 2, Vector3.zero, out outhit,BuildingsLayer);

        if(!bAreaIsFree)
        {
            GameObject.Instantiate(CactusPrefab, SpawnPosition, Quaternion.identity);
            CactusSpawned++;
        }
        else
        {
            SpawnCactus();
        }


        TimeToInvokeNewCactus = Random.Range(5.0f, 10.0f);
    }
}
