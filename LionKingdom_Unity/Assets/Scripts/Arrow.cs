using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float dieTime;
    public float damage;

    void Start()
    {
        StartCoroutine(CountDownTime());
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
    
    void OnBecameInvisible()
    {
         Destroy(gameObject);
    }
     
    IEnumerator CountDownTime()
    {
        yield return new WaitForSeconds(dieTime);
        
        Destroy(gameObject);
    }
}
