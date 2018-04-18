using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		GameManager.manager.contactButton = GameObject.FindGameObjectWithTag ("contactbutton");
		GameManager.manager.contactNotif = GameObject.FindGameObjectWithTag ("msgNotif");

		GameManager.manager.suspectButton = GameObject.FindGameObjectWithTag ("suspectbutton");
		GameManager.manager.suspectNotif = GameObject.FindGameObjectWithTag ("suspectNotif");
	}
	
	// Update is called once per frame
	void Update () {
		GameManager.manager.MessageAlert ();
	}
}
