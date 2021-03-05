using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_move : MonoBehaviour
{

	public float speed;
	public bool moveRight = true;

	// Use this for initialization
	void Update()
	{
		// Use this for initialization
		if (moveRight)
		{
			transform.Translate(2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(1, 1);
		}
		else
		{
			transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
			transform.localScale = new Vector2(-1, 1);
		}
	}

	void OnTriggerEnter2D(Collider2D turn_trig)
    {
		if (turn_trig.gameObject.CompareTag("turn"))
		{
			if (moveRight)
			{
				moveRight = false;
			}
			else
			{
				moveRight = true;
			}
		}
    }
}
