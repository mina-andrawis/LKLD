using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public Animator animator;

    float FireRate = 1;
    float NextFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > NextFire)
        {

          //If the player fired, reset the NextFire time to a new point in the future.
            NextFire = Time.time + FireRate;

            Shoot();
            animator.SetBool("IsFiring", true);

        }else if(Input.GetButtonUp("Fire1"))
        {
            animator.SetBool("IsFiring", false);
        }
    }

    void Shoot()
    {
        // shooting logic
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
