using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public bool win = false;
	public bool lose = false;

	public GameObject canvasToEnable;

	// Use this for initialization
	void Awake () {
		canvasToEnable = GameObject.FindGameObjectWithTag(TagManager.CANVAS_TO_ENABLE_ENDSCENE);
	}
	
	// Update is called once per frame
	void Update () {

		if(win){
			LevelClear();	
		}

		if(lose){
			LevelFailed();
		}
		
	}

	void LoseConditions(){
		if(GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).GetComponent<Health>().health.numberOfHearts <=0){
			lose = true;
		}
	}

	void LevelClear(){
		// display angry birds style win menu with 3 sstars
		//
		canvasToEnable.GetComponent<Canvas>().enabled = true;
		//LevelManager.instance.LoadNextLevel();
	}

	void LevelFailed(){
		//display angry birds style lose menu with level  failed display
	}

	void OnTriggerEnter(Collider other) {
		win = true;
		other.gameObject.SetActive(false)	;
	}	
}
