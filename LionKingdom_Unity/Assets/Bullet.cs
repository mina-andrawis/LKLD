using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 30;
    public float speed = 20;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        // fires at set speed
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //
        if (collision.GetComponent<Enemy>())
        {
            Debug.Log(collision.name);
            Enemy enemy = collision.GetComponent<Enemy>();

            // checks if the bullet hit an enemy and deals damage
            if (enemy != null)
            {
                Debug.Log("Damage given: " + damage);

                enemy.TakeDamage(damage);
            }

            Destroy(gameObject);

        }

        // bullet keeps going

        // add a check for if bullet hits something that isn't the background
        // like a wall or platform, then just destroy the bullet

        // add check for if bullet goes off the current visible camera screen,
        // then destroy the bullet
        else if(collision.CompareTag("Blocks"))
        {
            Destroy(gameObject);
        }
    }
    
    void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
