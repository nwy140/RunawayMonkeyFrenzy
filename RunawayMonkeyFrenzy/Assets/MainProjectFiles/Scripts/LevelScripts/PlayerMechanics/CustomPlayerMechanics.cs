using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlayerMechanics : MonoBehaviour {

	private Rigidbody myBody;
	private Animator anim;
	private PlayerController playerController; 

	// Use this for initialization
	void Awake () {
		myBody = transform.parent.GetComponent<Rigidbody>();
		anim = transform.parent.GetComponent<Animator>();
		playerController =  transform.parent.GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		LockXPositionOnAttack();
	}

	void LockXPositionOnAttack(){
		if(playerController.grounded.currentlyGrounded == true && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")  && (myBody.velocity.x > 0 || myBody.velocity.x < 0) ){
			playerController.movement.sideScrolling.movementSpeedIfAxisLocked = 0;
		} 
		if(myBody.velocity.x ==0 || anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") ==false ){
			playerController.movement.sideScrolling.movementSpeedIfAxisLocked = 6;		
		}
	}
}
