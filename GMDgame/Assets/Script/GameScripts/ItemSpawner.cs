using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]
    List<GameObject> spawnObjects;


    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < 1000; i++)
        {
            int randomIndex = Random.Range(0, spawnObjects.Count);

            // make Vector3 with global coordinates xVal and zVal (Y doesn't matter):
            Vector3 randomPosition = new Vector3(Random.Range(0, 1001), 0, Random.Range(0, 1001));

            // set the Y coordinate according to terrain Y at that point:
            randomPosition.y = Terrain.activeTerrain.SampleHeight(randomPosition) + Terrain.activeTerrain.GetPosition().y;
            // you probably want to create the object a little above the terrain:
            randomPosition.y += 1f; // move position 0.5 above the terrain

            //Instantiate(spawnObjects[randomIndex], randomPosition, Quaternion.identity);

            // Gets the orientation vector of the terrain and sets the orientation of the object to instantiate
            Vector3 normal = Terrain.activeTerrain.terrainData.GetInterpolatedNormal(randomPosition.x / Terrain.activeTerrain.terrainData.size.x, randomPosition.z / Terrain.activeTerrain.terrainData.size.z);
            Quaternion rotation = Quaternion.LookRotation(normal);
            Quaternion newRotation = rotation * Quaternion.Euler(90, 0, 0);

            Instantiate(spawnObjects[randomIndex], randomPosition, newRotation);
        }
    }

}
