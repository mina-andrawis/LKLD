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

    public bool checkPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        checkPoint = false;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Potion"))
        {
            currentHealth += 50;
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            checkPoint = true;
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
            if (checkPoint)
            {
                transform.Translate(1912, 310, 0);
                currentHealth = maxHealth;
                //BossHealth bossHealth = GameObject.FindObjectOfType<BossHealth>();
                //bossHealth.currentHealth = 200;
            }
            else
            {
                Die();
            }
            //Die();
        }
    }


    void Die()
    {

        Application.LoadLevel(Application.loadedLevel);
     
    }
}
