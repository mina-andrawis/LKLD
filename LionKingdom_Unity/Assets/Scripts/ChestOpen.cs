using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
  


    public Animator animator;
    public GameObject Player;
    public GameObject Target;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        radius = Vector3.Distance(Player.transform.position, Target.transform.position);

        if (radius < 5f)
        {
            animator.SetBool("IsOpen", true);
            Debug.Log("Animation played");
        }
        else
        {
            animator.SetBool("IsOpen", false);

        }
    }
}