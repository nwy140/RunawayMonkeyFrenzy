using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPatrol : MonoBehaviour {

	//array of walking points
	public Transform[] moveSpots; 
	private int randomSpot;

	private float waitTime;
	public float startWaitTime;
	public float speed;
	public float stoppingDistance = 0.2f;
	public bool randomPatrol;
	public float randomMinX,randomMaxX, randomMinY, randomMaxY;
	public Vector3 rotation;
	public bool onlyRotateWhenMoving;
	void Start(){
		waitTime = startWaitTime;
		randomSpot = Random.Range(0,moveSpots.Length);

	}

	void Update(){
		if(randomPatrol){
			RandomPatrol();
		} else{
			NavigatePatrol();
		}
		SetRotation();
	}
	void NavigatePatrol(){
		transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
		
		if(Vector3.Distance(transform.position,moveSpots[randomSpot].position) < stoppingDistance ) {
			if(waitTime<=0){
				randomSpot = Random.Range(0,moveSpots.Length);
				waitTime = startWaitTime;
			} else{
				waitTime -= Time.deltaTime;
			}
		}
	}
	void RandomPatrol(){
			transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
		if(Vector3.Distance(transform.position,moveSpots[randomSpot].position) < stoppingDistance ) {
			if(waitTime<=0){
				transform.position = new Vector3(Random.RandomRange(randomMinX,randomMaxX) + transform.position.x, Random.RandomRange( randomMinY , randomMaxY ) + transform.position.y, 0f + transform.position.z) ;				
				waitTime = startWaitTime;
			} else{
				waitTime -= Time.deltaTime;
			}
		}	
	}

	void SetRotation(){
		if(onlyRotateWhenMoving){
			if(waitTime<=0){
				transform.Rotate(rotation.x, rotation.y, rotation.z);
			}
		} else{
			transform.Rotate(rotation.x, rotation.y, rotation.z);

		}

	}

}

