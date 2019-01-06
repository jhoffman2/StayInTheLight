using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : MonoBehaviour
{

    public int startingHealth = 100;
    public int currentHealth;
    public int hitDamage = 1;
    public bool isDead;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay (Collider other)
    {

        if (other.gameObject.tag == "light")
        {
            TakeDamage();
        }
    }

    void TakeDamage ()
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= hitDamage;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
            Debug.Log("Monster is dead.");
        }
    }
}
