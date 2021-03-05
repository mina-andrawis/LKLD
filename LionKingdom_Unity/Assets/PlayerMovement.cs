using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D monkeyController;
    public Animator animator;
	public float runningSpeed = 40f;
	float horizontalMotion = 0f;
	bool jump = false;
	bool crouch = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMotion = Input.GetAxisRaw("Horizontal") * runningSpeed;
        
        animator.SetFloat("Speed", Mathf.Abs(horizontalMotion));
		
		if(Input.GetButtonDown("Jump"))
		{
			jump = true;
            animator.SetBool("isJumping", true);
		}
		
		if(Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if(Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}
    }
    
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }
	
	void FixedUpdate()
	{
		//Move the monkey
		monkeyController.Move(horizontalMotion * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
