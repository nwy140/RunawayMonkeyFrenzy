using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatfesdddde : MonoBehaviour {

	public bool win = false;
	public bool lose = false;

	// Use this for initialization
	void Start () {
		
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

	void LevelClear(){
		// display angry birds style win menu with 3 sstars
		// 
	}

	void LevelFailed(){
		//display angry birds style lose menu with level  failed display
	}
}
