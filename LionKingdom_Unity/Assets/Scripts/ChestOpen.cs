using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{

    private float radius;
    private float distance;

    public Animator anim;
    public GameObject Player;
    public GameObject Target;

    public SpriteResolver mySpriteResolver;

    //retrieve spriteLibrary that the SpriteResolver is resolving from
    public SpriteLibrary spriteLibrary { get; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        mySpriteResolver = GetComponent<SpriteResolver>();
        Player = GameObject.FindWithTag("Player");
        Target = GameObject.FindWithTag("Chest");
    }

    private void Update()
    {
        radius = Vector3.Distance(Player.transform.position, Target.transform.position);
        //Debug.Log(radius);

        if (radius < 60f )
        {
            //GetComponent<Animator>().SetBool("isOpened",true);
            //Debug.Log(mySpriteResolver.GetLabel());
            //Debug.Log("Animation played");
            mySpriteResolver.SetCategoryAndLabel("Chest", "OpenChest");
        }
    }
}