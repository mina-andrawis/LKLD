using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public int damage = 30;
    public float speed = 20;
    public Rigidbody2D rb;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>())
        {
            Debug.Log(collision.name);
            Enemy enemy = collision.GetComponent<Enemy>();
            Enemy enemyHealth = collision.GetComponent<Enemy>();
            
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Damage given: " + damage);
                
                enemyHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
