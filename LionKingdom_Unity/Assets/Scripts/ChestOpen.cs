using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private float radius;
    private float distance;
    public Animator anim;
    public GameObject Player;
    public GameObject Target;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        radius = Vector3.Distance(Player.transform.position, Target.transform.position);

        if (radius < 1f && Input.GetMouseButtonDown(1))
        {
            GetComponent<Animator>().SetTrigger("isOpened");
            Debug.Log("Animation played");
        }
    }
}