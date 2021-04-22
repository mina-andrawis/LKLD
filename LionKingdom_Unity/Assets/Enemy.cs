using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed;
    public bool moveRight;
    public Animator animator;
    BossHealth bossHealth;

    void Start()
    {
        bossHealth = GameObject.FindObjectOfType<BossHealth>();
        GetComponent<SwordAttack>().enabled = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("IsDead") == true){
            this.GetComponent<Collider2D>().enabled = false;
            return;
        }
        
        // if move right is true
        speed = 8;
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(-8, 8);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            transform.localScale = new Vector2(8, 8);
        }
        
        if(bossHealth.currentHealth <= 80 && bossHealth.currentHealth > 40)
        {
            GetComponent<SwordAttack>().enabled = false;
            GetComponent<ArrowAttack>().enabled = true;
        }
        else if(bossHealth.currentHealth <= 40)
        {
            GetComponent<ArrowAttack>().enabled = false;
            GetComponent<BombAttack>().enabled = true;
        }
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("turn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }
    }
}
