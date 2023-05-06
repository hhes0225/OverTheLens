using System.Collections;
using UnityEngine;

namespace Script.Character
{
    public class RandomPosition : MonoBehaviour
    {
        public const float TERRAIN_X_MIN = 0;
        public const float TERRAIN_X_MAX = 1000;
        public const float TERRAIN_Z_MIN = 0;
        public const float TERRAIN_Z_MAX = 1000;
        public GameObject player;
        
        IEnumerator Start ( )
        {
            yield return new WaitForSeconds ( .25f );
            SpawnPlayer ( );
        }
        
        public void SpawnPlayer ( )
        {
            var safetyCount = 0;
            var safetyLimit = 100;
            do
            {
                var rayStart = new Vector3(Random.Range(TERRAIN_X_MIN, TERRAIN_X_MAX), 150, Random.Range(TERRAIN_Z_MIN, TERRAIN_Z_MAX));
                if ( !Physics.Raycast ( rayStart, Vector3.down, out var hit, Mathf.Infinity ) )
                    continue;
                
                var spawnedPlayer = Instantiate(player, transform).transform;
                spawnedPlayer.position = new Vector3 ( hit.point.x, hit.point.y + Random.Range ( 35, 300 ), hit.point.z );
                spawnedPlayer.rotation *= Quaternion.FromToRotation ( Vector3.up, hit.normal );
                spawnedPlayer.Rotate ( spawnedPlayer.up, Random.Range ( 0, 360 ), Space.World );

                Debug.Log ( "Spawned Player" );
                return;
            } while ( true && safetyCount++ < safetyLimit );
            Debug.LogWarning ( $"Could not spawn player after {safetyLimit} attempts. Are your ray start values correct?" );
            
            /*RaycastHit hit;

            Vector3 randomPosition = new Vector3(Random.Range(0, 1001), 164, Random.Range(0, 1001));
            if (Physics.Raycast(randomPosition + Vector3.up, Vector3.down, out hit, 2000.0f))
            {
                Instantiate(player, hit.point, Quaternion.identity);
            }
            else
            {
                Debug.Log("there seems to be no ground at this position");
            }*/
            
        }
    }
}
