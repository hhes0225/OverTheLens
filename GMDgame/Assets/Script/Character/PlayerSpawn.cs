using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        // make Vector3 with global coordinates xVal and zVal (Y doesn't matter):
        Vector3 randomPosition = new Vector3(Random.Range(0, 1001), 0, Random.Range(0, 1001));

        // set the Y coordinate according to terrain Y at that point:
        randomPosition.y = Terrain.activeTerrain.SampleHeight(randomPosition) + Terrain.activeTerrain.GetPosition().y;
        // you probably want to create the object a little above the terrain:
        randomPosition.y += 1f; // move position 0.5 above the terrain

        player.transform.position = randomPosition;
    }

    
}
