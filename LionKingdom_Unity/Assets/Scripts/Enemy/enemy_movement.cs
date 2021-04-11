using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool moveRight;
    public Animator animator;
    
    public float range;
    public float timeBTWShots;
    private float distToPlayer;
    public Rigidbody2D rb;
    public float shootSpeed;
    
    public Transform firePoint;
    public Transform player;
    public GameObject arrowPrefab;
    private bool canShoot;

    void Start()
    {
        canShoot = true;
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
        
        distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer <= range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }
            moveRight = false;
            rb.velocity = Vector2.zero;
            
            if(canShoot == true)StartCoroutine(Shoot());
        }
        else
        {
            moveRight = true;
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
    
    void Flip()
    {
        moveRight = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        speed *= -1;
        moveRight = true;
    }
    
    IEnumerator Shoot()
    {
        canShoot = false;
        
        yield return new WaitForSeconds(timeBTWShots);
        
        GameObject newArrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        
        newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * speed * Time.fixedDeltaTime, 0f);
    }
}
