using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //in order to create variable to store slider
using UnityEngine.SceneManagement;


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
            if(currentHealth > 100)
            {
                currentHealth = maxHealth;
            }
            healthBar.SetHealth(currentHealth);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            //GameObject.Find("Main Camera").active = false;
            //GameObject.Find("BossCamera").active = true;
            SceneManager.LoadScene("BossLevel");
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
