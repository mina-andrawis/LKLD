using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //in order to create variable to store slider


public class Enemy : MonoBehaviour
{

  public Animator animator;
	
	public int maxHealth = 100;
	int currentHealth;
    public HealthBar healthBar;
	
	//Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
	}
	
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
		
		if(currentHealth <= 0)
		{
			Die();
		}
	}
	
	void Die()
	{
		Debug.Log("Enemy died!");
		
		animator.SetBool("IsDead", true);
		
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
	}
}

