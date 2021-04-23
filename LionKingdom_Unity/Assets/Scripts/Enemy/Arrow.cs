using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int damage = 10;
    public float speed = 17;
    public Rigidbody2D rb;

    PlayerMovement target;
    PlayerHealth health;
    Vector2 moveDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        health = GameObject.FindObjectOfType<PlayerHealth>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player"))
        {
            health.TakeDamage(5);
            Destroy(gameObject);
        }
        
        else if(collision.CompareTag("Blocks"))
        {
            Destroy(gameObject);
        }
    }
    
    void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
