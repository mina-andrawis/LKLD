using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D monkeyController;
	public float runningSpeed = 40f;
	float horizontalMotion = 0f;
	bool jump = false;
	bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMotion = Input.GetAxisRaw("Horizontal") * runningSpeed;
		
		if(Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
		
		if(Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if(Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
    }
	
	void FixedUpdate()
	{
		//Move the monkey
		monkeyController.Move(horizontalMotion * Time.fixedDeltaTime, crouch, jump);
		jump = false;
		crouch = false;
	}
}
