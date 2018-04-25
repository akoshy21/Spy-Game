using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {

	public GameObject handlerButton;
	public GameObject handlerNotif;

	public GameObject suspectButton;
	public GameObject suspectNotif;


	public static Variables variable;

	void Awake()
	{
		variable = this;
	}
	
	// Update is called once per frame
	void Update () {
		GameManager.manager.MessageAlert ();
	}
}
