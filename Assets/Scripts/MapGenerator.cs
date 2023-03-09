using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField]Transform ConstructionPointsHandler;
    Transform[] ConstructionPoints; //Positions where buildings will be constructed

    [Header("Buildings to be constructed")]
    [SerializeField] GameObject[] BuildingsPrefabs;

    private void Awake()
    {
        ConstructionPoints = ConstructionPointsHandler.GetComponentsInChildren<Transform>();
    }

    public void GenerateMap()
    {
        foreach(Transform position in ConstructionPoints)
        {
            int randomIndex = Random.Range(0, BuildingsPrefabs.Length); //Choose a randon building...
            float randomYRotation = Random.Range(-30, 30); //With a random rotation between -30 and 330 degrees...
            GameObject.Instantiate(BuildingsPrefabs[randomIndex], position.position, Quaternion.Euler(0, randomYRotation, 0)); //And build it
        }

        Destroy(ConstructionPointsHandler.gameObject);
        Destroy(this);
    }
}
