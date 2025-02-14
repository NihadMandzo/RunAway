using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerHealth : MonoBehaviour
    {
        public float maxHealth = 5;
        private float currentHealth = 0;
        public void Start()
        {
            currentHealth = maxHealth;

        }

        private void OnCollisionStay(Collision other)
        {
            if(currentHealth <= 0)Debug.Log("Ljudi ubi me Aca");
            if (other.gameObject.CompareTag("Body"))
            {
                Debug.Log(currentHealth);
                TakeDamage(0.01f);
            }
        }


        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            //Animator.SetTrigger("Damage");
            if (currentHealth<=0)
            {
                Die();
            }
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}