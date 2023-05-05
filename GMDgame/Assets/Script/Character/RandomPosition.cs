using UnityEngine;

namespace Script.Character
{
    public class RandomPosition : MonoBehaviour
    {
        public GameObject player;
        
        void Start()
        {
            RaycastHit hit;

            Vector3 randomPosition = new Vector3(Random.Range(0, 1001), 164, Random.Range(0, 1001));
            if (Physics.Raycast(randomPosition + Vector3.up, Vector3.down, out hit, 2000.0f))
            {
                Instantiate(player, hit.point, Quaternion.identity);
            }
            else
            {
                Debug.Log("there seems to be no ground at this position");
            }
            
        }
    }
}
