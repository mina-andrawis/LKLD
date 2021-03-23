using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public Animator animator;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            Die();
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        Task.Delay(3000);
        Destroy(gameObject);
    }
}
