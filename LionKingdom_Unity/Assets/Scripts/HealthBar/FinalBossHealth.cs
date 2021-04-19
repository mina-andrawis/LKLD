using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //in order to create variable to store slider


public class FinalBossHealth : MonoBehaviour
{

	public Animator animator;
	public GameObject healthPotion;
	public Transform dropPoint;

	public int maxHealth = 100;
	int currentHealth;
	public HealthBar healthBar;

	public DialogueTrigger trigger;

	//Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		animator.SetTrigger("IsHurt");
		healthBar.SetHealth(currentHealth);

		if (currentHealth <= 0)
		{
			animator.SetBool("IsDead", true);
			Die();
		}
	}

	void Die()
	{
		if (Random.Range(0f, 1f) <= .25)
		{
			Instantiate(healthPotion, dropPoint.position, dropPoint.rotation);
		}

		Debug.Log("Enemy died!");
		GetComponent<Collider2D>().enabled = false;

		this.enabled = false;
		Destroy(gameObject, 2);

		trigger.TriggerDialogue();
		//start dialogue box system
	}
}