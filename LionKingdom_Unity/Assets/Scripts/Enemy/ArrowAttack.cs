using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : MonoBehaviour
{
    public GameObject arrowPrefab;
    
    public float fireRate;
    public float nextFire;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1.5f;
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
            animator.SetTrigger("IsShooting");
            Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
