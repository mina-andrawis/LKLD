using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //in order to create variable to store slider


public class PlayerHealth : MonoBehaviour
{

  public int maxHealth = 30;
  public int currentHealth;

  public HealthBar healthBar;
  public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
      Debug.Log("INISDE");
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          TakeDamage(5);
        }
    }

    void TakeDamage(int damage)
    {
      currentHealth -= damage;
      healthBar.SetHealth(currentHealth);
      if(currentHealth <=0)Die();
    }
    
    void Die()
    {
        animator.SetBool("IsDead", true);
        Application.LoadLevel(Application.loadedLevel);
    }
}
