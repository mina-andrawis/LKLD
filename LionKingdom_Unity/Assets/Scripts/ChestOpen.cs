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
        Player = GameObject.FindWithTag("Player");
        Target = GameObject.FindWithTag("Chest");
    }

    private void Update()
    {
        radius = Vector3.Distance(Player.transform.position, Target.transform.position);
        Debug.Log(radius);

        if (radius < 60f )
        {
            GetComponent<Animator>().SetBool("isOpened",true);
            Debug.Log("Animation played");
        }
    }
}