using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BombEnemy : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    public int damage = 30;
    public float splashRange = 1;
    public Animator animator;
    
    public Rigidbody2D rb;
    PlayerMovement target;
    PlayerHealth health;
    Vector2 moveDirection;
    
    private void Start()
    {
        if(Thrown)
        {
            rb = GetComponent<Rigidbody2D>();
            target = GameObject.FindObjectOfType<PlayerMovement>();
            health = GameObject.FindObjectOfType<PlayerHealth>();
            moveDirection = (target.transform.position - transform.position).normalized * Speed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
        transform.Translate(LaunchOffset);
        Destroy(gameObject, 5);
    }
    
    public void Update()
    {
        if(!Thrown)
        {
            transform.position += transform.right * Speed * Time.deltaTime;
        }
        
    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(splashRange > 0)
        {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
            foreach(var hitCollider in hitColliders)
            {
                var player = hitCollider.GetComponent<PlayerMovement>();
                var playerHealth = hitCollider.GetComponent<PlayerHealth>();
            
                if(player)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);
                    var damagePercent = Mathf.InverseLerp(splashRange, 0, distance);
                    
                    playerHealth.TakeDamage((int)Math.Round(damagePercent * damage));
                }
            }
        }
        else
        {
            var player = collision.collider.GetComponent<PlayerMovement>();
            var playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if(player)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        animator.SetTrigger("IsExploding");
        
        Destroy(gameObject, 1);
    }
    
    void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
