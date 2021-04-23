using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour
{
    public GameObject bombPrefab;

    public float fireRate;
    public float nextFire;
    public Animator animator;
    float dist;
    public GameObject player;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
      if (GetComponent<Enemy>() !=null)
      {
        fireRate = 3f;

      }
      if (GetComponent<BossHealth>() != null)
      {
        fireRate = 2.2f;

      }
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.transform.position, gameObject.transform.position);
        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire()
    {
        if(Time.time > nextFire && dist < range)
        {
            animator.SetTrigger("IsThrowing");
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
