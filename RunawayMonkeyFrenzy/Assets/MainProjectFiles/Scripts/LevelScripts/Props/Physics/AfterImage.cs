using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImage : MonoBehaviour {

	//array of walking points
	public Transform[] walkpoints; 
	public float speed = 5f;
	private int walk_Index = 0;
	private Transform playerTarget;
	private Animator anim;
//	private NavMeshAgent navAgent;
	private Rigidbody myBody;
	private float walk_Distance = 8f;
	private float attack_Distance = 2f;
	private float currentAttackTime;
	private float waitAttackTime = 1f;

	private Vector3 nextDestination;
//	private EnemyHealth enemyHealth;
	
	// Use this for initialization
	void Awake () {
		playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
		anim = GetComponent<Animator>();
		myBody = GetComponent<Rigidbody>();
//		navAgent = GetComponent<NavMeshAgent>();
//		enemyHealth = GetComponent<EnemyHealth>();			
	}
	
	// Update is called once per frame
	void Update () {
//		if(enemyHealth.health>0){
			MoveAndAttack();
//		} else{
//		anim.SetBool("Death",true);
		// 	navAgent.enabled=false;	
			
		// 	if(!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Death")
		// 		&& anim.GetCurrentAnimatorStateInfo(0).normalizedTime>=0.95f){
					
		// 			Destroy (gameObject, 2f);
		// 	}	
		// }
	}

	void MoveAndAttack(){
			float distance = Vector3.Distance(transform.position, playerTarget.position);

		// if (distance > walk_Distance){

			// if(navAgent.remainingDistance<=0.5f){


				// navAgent.isStopped = false; // nav mesh is working	
				// anim.SetBool("Walk",true);
				// anim.SetBool("Run",false);
				// anim.SetInteger("Atk",0);

				nextDestination = walkpoints[walk_Index].position;
				moveTo(nextDestination);
				// navAgent.SetDestination(nextDestination);

				//reset index
				if(walk_Index == walkpoints.Length-1){
					walk_Index=0;
				} else{
					walk_Index++;
				}
			// }
		} 
		// else{
			// if(distance>attack_Distance){

			// // 	// activate navAgent again
			// // 	navAgent.isStopped = false;
			// // 	anim.SetBool("Walk",false);
			// // 	anim.SetBool("Run",true);
			// // 	anim.SetInteger("Atk",0);
				
			// // 	nextDestination = playerTarget.position;
			// // 	navAgent.SetDestination(nextDestination);
			// // } else{
			// // 	navAgent.isStopped = true;
			// // 	anim.SetBool("Run",false);
			// // 	Vector3 targetPosition = new Vector3 (playerTarget.position.x, transform.position.y, playerTarget.position.z);
			// // 	//Lerp rotation towards target enemy
			// // 	transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPosition-transform.position) ,Time.deltaTime);

			// // 	// Attacking
			// // 	if(currentAttackTime>=waitAttackTime){
			// // 		int atkRange = Random.Range(1,3);
			// // 		anim.SetInteger("Atk",atkRange);
			// // 	} else {
			// // 		anim.SetInteger("Atk", 0);
			// // 		currentAttackTime += Time.deltaTime;
			// // 	}
	// 		}
	// 	}
	// }

	void moveTo(Vector3 targetPosition){
		    myBody.MovePosition(targetPosition + transform.forward * Time.deltaTime);

	}


}
