using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon3 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bombPrefab;
    public Animator animator;

    float FireRate = 1;
    float NextFire;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3") && Time.time > NextFire)
        {

          //If the player fired, reset the NextFire time to a new point in the future.
            NextFire = Time.time + FireRate;

            Throw();
            animator.SetBool("IsThrowing", true);

        }else if(Input.GetButtonUp("Fire3"))
        {
            animator.SetBool("IsThrowing", false);
        }
    }

    void Throw()
    {
        // throwing logic
        Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
    }
}
