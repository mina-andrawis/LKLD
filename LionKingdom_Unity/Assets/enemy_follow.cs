using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_follow : MonoBehaviour
{

    public float speed;
    public Transform Target;
    public bool follow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        speed = 30;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (follow == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            follow = true;
            Debug.Log("Player here");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            follow = false;
            Debug.Log("Player gone");
        }
    }


}
