using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactAppManager : MonoBehaviour {

	public string noteText;
	public int contact = 0;

	public Text contactZero;

	// Use this for initialization
	void Enable () {
		// contactZero.text = GameManager.manager.no [0].text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnString_Notes(string value)
	{
		// set player name to the value of the uppercased value of the input
		// GameManager.manager.no[contact].text = value;
	}
}
