using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bomb : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    public int damage = 30;
    public float splashRange = 1;
    public Animator animator;
    
    private void Start()
    {
        if(Thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
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
                var enemy = hitCollider.GetComponent<Enemy>();
                var boss = hitCollider.GetComponent<BossHealth>();
            
                if(enemy)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);
                    var damagePercent = Mathf.InverseLerp(splashRange, 0, distance);
                    enemy.TakeDamage((int)Math.Round(damagePercent * damage));
                }
                else if(boss)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);
                    var damagePercent = Mathf.InverseLerp(splashRange, 0, distance);
                    boss.TakeDamage((int)Math.Round(damagePercent * damage));
                }
            }
        }
        else
        {
            var enemy = collision.collider.GetComponent<Enemy>();
            var boss = collision.collider.GetComponent<BossHealth>();
            
            if(enemy)
            {
                enemy.TakeDamage(damage);
            }
            
            else if(boss)
            {
                boss.TakeDamage(damage);
            }
        }
        animator.SetTrigger("IsExploding");
        
        Destroy(gameObject, 1);
    }
    
    void OnBecameInvisible() {
         Destroy(gameObject);
     }
}
