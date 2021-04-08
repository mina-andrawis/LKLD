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
    public GameObject Chest;
    public GameObject BowAndArrow;

    public SpriteResolver mySpriteResolver;

    //retrieve spriteLibrary that the SpriteResolver is resolving from
    public SpriteLibrary spriteLibrary { get; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        mySpriteResolver = GetComponent<SpriteResolver>();
        Player = GameObject.FindWithTag("Player");
        Chest = GameObject.FindWithTag("Chest");
        BowAndArrow = GameObject.FindWithTag("BowAndArrow");
        BowAndArrow.SetActive(false);   //make invisible until chest opens

    }

    private void Update()
    {
        radius = Vector3.Distance(Player.transform.position, Chest.transform.position);
        //Debug.Log(radius);

        if (radius <40f)
        {
            GetComponent<Animator>().SetBool("isOpen",true);
            Debug.Log(GetComponent<Animator>().GetBool("isOpen"));
            BowAndArrow.SetActive(true);   //make visible
            mySpriteResolver.SetCategoryAndLabel("Chest", "OpenChest");
        }
    }
}