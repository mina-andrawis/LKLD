using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestOpen : MonoBehaviour
{

    private float radius;
    private float distance;

    public Animator anim;
    public GameObject Player;
    public GameObject Chest;
    public GameObject Gun;
    public GameObject DialogueBox;

    public SpriteResolver mySpriteResolver;

    public bool isRunning;

    public FadeObject blackBox;


    //retrieve spriteLibrary that the SpriteResolver is resolving from
    public SpriteLibrary spriteLibrary { get; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        mySpriteResolver = GetComponent<SpriteResolver>();
        Player = GameObject.FindWithTag("Player");
        Chest = GameObject.FindWithTag("Chest");
        DialogueBox = GameObject.FindWithTag("NewWeaponDialogue");
        DialogueBox.SetActive(false);   //make invisible until chest opens

        Gun = GameObject.FindWithTag("Gun");
        Gun.SetActive(false);   //make invisible until chest opens

        isRunning = false;

    }

    private void Update()
    {
        radius = Vector3.Distance(Player.transform.position, Chest.transform.position);
        //Debug.Log(radius);
        if (radius < 60f)
        {
            GetComponent<Animator>().SetBool("isOpen", true);
            Gun.SetActive(true);   //make visible
            DialogueBox.SetActive(true);   //make visible

            mySpriteResolver.SetCategoryAndLabel("Chest", "OpenChest");

            if (!isRunning)
            {
                StartCoroutine(endLevel());
            }


        }
}

    //wait 8 seconds before fading to black and starting next level
    IEnumerator endLevel()
    {
        isRunning = true;

        yield return new WaitForSeconds(8);
        blackBox.Fade();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SecondLevel");

        isRunning = false;
    }




}
