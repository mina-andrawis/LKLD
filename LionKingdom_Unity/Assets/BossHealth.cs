using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public Animator animator;
    public GameObject healthPotion;
    public Transform dropPoint;

	public int maxHealth = 200;
	public int currentHealth;
    public HealthBar healthBar;

	public DialogueTrigger trigger;

  public AudioSource _AudioSource1;
  public AudioSource _AudioSource2;


	//Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        _AudioSource2.Stop();

	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
        animator.SetTrigger("IsHurt");
        healthBar.SetHealth(currentHealth);

		if(currentHealth <= 0)
		{
            animator.SetBool("IsDead", true);
			Die();
		}
	}

	void Die()
	{

    GetComponent<SwordAttack>().enabled = false;
    GetComponent<ArrowAttack>().enabled = false;
    GetComponent<BombAttack>().enabled = false;

        if (Random.Range (0f, 1f) <= .25)
        {
            Instantiate (healthPotion, dropPoint.position, dropPoint.rotation);
        }

		Debug.Log("Enemy died!");
		GetComponent<Collider2D>().enabled = false;

		this.enabled = false;
        Destroy(gameObject, 2);

		trigger.TriggerDialogue();
		//start dialogue box system


    _AudioSource1.Stop();
   _AudioSource2.Play();


	}
}
