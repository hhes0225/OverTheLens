using System;
using System.Collections;
using UnityEngine;

namespace Script.Trap
{
    public class Damage : MonoBehaviour
    {
        private bool _isCausingDamage;

        public float DamageRepeatRate = 0.1f;

        public int DamageAmount = 1;

        public bool Repeating = true;

        private void OnTriggerEnter(Collider other)
        {
            _isCausingDamage = true;

            Debug.Log("you touched trap");

            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                if (Repeating)
                {
                    // Repeat damage
                    StartCoroutine(TakeDamage(player, DamageRepeatRate));
                }
                else
                {
                    // Just one time damage
                    player.PlayerDamaged(DamageAmount);
                }
            }
        }

        IEnumerator TakeDamage(Player player, float repeatRate)
        {
            while (_isCausingDamage)
            {
                player.PlayerDamaged(DamageAmount);
                TakeDamage(player, repeatRate);
                yield return new WaitForSeconds(repeatRate);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                _isCausingDamage = false;
            }
        }
    }
}
