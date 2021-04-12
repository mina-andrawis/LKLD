using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool moveRight;
    public Animator animator;

    void Start()
    {
        GetComponent<ArrowAttack>().enabled = false;
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
    
    void OnBecameVisible()
    {
        GetComponent<ArrowAttack>().enabled = true;
    }
    
    void OnBecameInvisible()
    {
        GetComponent<ArrowAttack>().enabled = false;
    }

}
