using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public GameObject bombPrefab;
    
    public float fireRate;
    public float nextFire;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 2f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }
    
    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire)
        {
            animator.SetTrigger("IsThrowing");
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
