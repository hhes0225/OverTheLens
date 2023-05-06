using UnityEngine;

namespace Script.GameScripts
{
    public class RandomSpawner : MonoBehaviour
    {
        public GameObject[] spawnObjects;
        
        void Awake()
        {
            RaycastHit hit;
            
            for (int i = 0; i < 1000; i++)
            {
                int randomIndex = Random.Range(0, spawnObjects.Length);
                Vector3 randomPosition = new Vector3(Random.Range(0, 1001), 0, Random.Range(0, 1001));
                if (Physics.Raycast(randomPosition + Vector3.up * 1000, Vector3.down, out hit, 2000.0f))
                {
                    Instantiate(spawnObjects[randomIndex], hit.point, Quaternion.identity);
                }
                else
                {
                    Debug.Log("there seems to be no ground at this position");
                }
            }
        }
    }
}


