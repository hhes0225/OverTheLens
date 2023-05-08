using System.Collections;
using UnityEngine;

namespace Script.Character
{
    //no longer used
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
                var rayStart = new Vector3(Random.Range(TERRAIN_X_MIN, TERRAIN_X_MAX), 170, Random.Range(TERRAIN_Z_MIN, TERRAIN_Z_MAX));
                if (!Physics.Raycast(rayStart, Vector3.down, out var hit, Mathf.Infinity))
                    continue;

                var spawnedPlayer = Instantiate(player, transform).transform;
                spawnedPlayer.position = new Vector3 ( hit.point.x, hit.point.y + Random.Range ( 35, 300 ), hit.point.z );
                spawnedPlayer.rotation *= Quaternion.FromToRotation ( Vector3.up, hit.normal );
                spawnedPlayer.Rotate ( spawnedPlayer.up, Random.Range ( 0, 360 ), Space.World );

                Debug.Log ( "Spawned Player" );
                return;
            } while ( true && safetyCount++ < safetyLimit );
            Debug.LogWarning ( $"Could not spawn player after {safetyLimit} attempts. Are your ray start values correct?" );

        }
    }
}
