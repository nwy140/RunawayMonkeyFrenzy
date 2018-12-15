using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject TeleportPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == TagManager.ENEMY_TAG || other.tag == TagManager.PLAYER_TAG){
			other.transform.position = TeleportPoint.transform.position;
			print("Teleporting to " + other.transform.position.ToString() );
			SoundManager.instance.PlayTeleportSound();	
		}	
	}

	void OnTriggerEnter(Collider other) {
			//if(other.tag == TagManager.ENEMY_TAG || other.tag == TagManager.PLAYER_TAG){
			other.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0	);
			other.transform.position = TeleportPoint.transform.position;
			
			print("Teleporting to " + other.transform.position.ToString() );
		//	SoundManager.instance.PlayTeleportSound();	
		//Manage Player Stats
//			other.GetComponent<PlayerController>().h	
	}

}
