using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bomb : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bombPrefab;
	public Animator animator;

	float fireRate = 1;
	float nextFire;

    // Update is called once per frame
    void Update()
    {
		if (Time.time > nextFire)
		{
			//If the player fired, reset the NextFire time to a new point in the future
			nextFire = Time.time + fireRate;

			Throw();
			animator.SetBool("IsThrowing", true);
		}
		else
		{
			animator.SetBool("IsThrowing", false);
		}
    }

	void Throw()
	{
		//throwing logic
		Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
	}
}
