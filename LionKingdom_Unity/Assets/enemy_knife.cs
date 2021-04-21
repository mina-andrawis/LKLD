using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_knife : MonoBehaviour
{

	public Animator animator;
	public Transform attackPoint;
	public LayerMask playerLayers;
	public GameObject knifePrefab;

	public float attackRange = 0.5f;
	public int attackDamage = 40;

	public float attackRate = 2f;
	float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
	{
		Attack();
		nextAttackTime = Time.time + 1f / attackRate;
	}
    }

	void Attack()
	{
		Instantiate(knifePrefab, attackPoint.position, attackPoint.rotation);
		//Play an attack animation
		animator.SetTrigger("IsAttacking");

		//Detect players in range of attack
		Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

		//Damage them
		foreach(Collider2D player in hitPlayers)
		{
			player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
		}
	}

	void OnDrawGismosSelected()
	{
		if(attackPoint == null)
			return;

		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
