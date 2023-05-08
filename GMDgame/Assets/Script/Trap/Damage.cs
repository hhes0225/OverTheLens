using System;
using System.Collections;
using UnityEngine;
using Script.Inventory;

namespace Script.Trap
{
    public class Damage : MonoBehaviour
    {
        private bool _isCausingDamage;

        public float DamageRepeatRate = 0.1f;

        public int DamageAmount = 1;

        public bool Repeating = true;

        public bool isProtected = false;

        public AudioClip protectedSound;


        private void OnTriggerEnter(Collider other)
        {
            _isCausingDamage = true;

            //Debug.Log("you touched trap");

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
                    if (!InventorySystem.Instance.isThereEquip()) { //player don't have equip(sword, shield)
                        // Just one time damage
                        //Debug.Log("Trap - Player damaged");
                        player.PlayerDamaged(DamageAmount);
                    }
                    else //player have equip
                    {
                        //Debug.Log("Trap - Player protected");
                        MusicManager.instance.SFXPlay("protectedSound", protectedSound);
                        InventorySystem.Instance.EquipAutoUse();
                    }
                }
            }
        }

        IEnumerator TakeDamage(Player player, float repeatRate)
        {
            while (_isCausingDamage)
            {
                if (!InventorySystem.Instance.isThereEquip())
                { //player don't have equip(sword, shield)
                  // Just one time damage
                  //Debug.Log("Trap - Player damaged");
                    player.PlayerDamaged(DamageAmount);
                }
                else //player have equip
                {
                    //Debug.Log("Trap - Player protected");
                    MusicManager.instance.SFXPlay("protectedSound", protectedSound);
                    InventorySystem.Instance.EquipAutoUse();
                    yield return null;
                }

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
