using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContactAppManager : MonoBehaviour {

	public string noteText;
	public int contact = 0;

	// prefabs
	public Text senderName;
	public Text message;
	public Image messageBox;

	/// public Text contactZero;

	// Use this for initialization
	void Enable () {
		// contactZero.tex= GameManager.manager.no [0].text;
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetKeyDown ("space"))
			{
			GameObject[] msgs;
			msgs = GameObject.FindGameObjectsWithTag("message");
			for(int i = 0; i <= msgs.Length; i++ ) {
				msgs[i].transform.Translate(0,50,0);
				Debug.Log ("beep" + i);
				new Messages("hi", Time.time.ToString(), senderName, message, messageBox, false);
					}
		}
	}

	public void OnString_Notes(string value)
	{
		// set player name to the value of the uppercased value of the input
		// GameManager.manager.no[contact].text = value;
	}
}
