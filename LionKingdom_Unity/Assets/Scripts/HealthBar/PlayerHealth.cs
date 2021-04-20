using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //in order to create variable to store slider


public class PlayerHealth : MonoBehaviour
{

  public int maxHealth = 100;
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
          TakeDamage(5);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Potion"))
        {
            currentHealth += 10;
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("IsHurt");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <=0)
        {
            animator.SetTrigger("IsDead");
            Die();
        }
    }
    
    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
