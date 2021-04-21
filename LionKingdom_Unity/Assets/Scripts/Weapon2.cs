using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
   public Animator animator;
	
	public Transform attackPoint;
	public LayerMask enemyLayers;
    public GameObject knifePrefab;
	
	public float attackRange = 0.5f;
	public int attackDamage = 40;
	
	public float attackRate = 2f;
	float nextAttackTime = 0f;
	
	//Update is called once per frame
	void Update()
	{
		if(Time.time >= nextAttackTime)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Attack();
				nextAttackTime = Time.time + 1f / attackRate;
			}
		}
	}
	
	void Attack()
	{
        Instantiate(knifePrefab, attackPoint.position, attackPoint.rotation);
		//Play an attack animation
		animator.SetTrigger("IsAttacking");
		
		//Detect enemies in range of attack
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		
		//Damage them
		foreach(Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
		}
	}
	
	void OnDrawGismosSelected()
	{
		if(attackPoint == null)
			return;
			
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
