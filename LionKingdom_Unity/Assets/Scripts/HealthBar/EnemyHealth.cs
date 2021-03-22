using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //in order to create variable to store slider


public class EnemyHealth : MonoBehaviour
{

  public int maxHealth = 100;
  public int currentHealth;

  public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          TakeDamage(34);
        }
    }

    void TakeDamage(int damage)
    {
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
    }
}
