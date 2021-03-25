using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
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
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

            // checks if the arrow hit an enemy and deals damage
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log("Damage given: " + damage);

                enemyHealth.TakeDamage(30);
            }

            Destroy(gameObject);

        }

        // arrow keeps going

        // add a check for if arrow hits something that isn't the background
        // like a wall or platform, then just destroy the arrow

        // add check for if arrow goes off the current visible camera screen,
        // then destroy the arrow
        else{
            return;
        }


    }
}
