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
//	List<Messages> messages;
//	GameObject[] boxes;


	/// public Text contactZero;

	// Use this for initialization
	void OnEnable () {
		/*if(GameManager.manager.msgs.Length > 0)
		{
			messages = GameManager.manager.msgs;

			for(int i = 0; i < GameManager.manager.msgBoxes.Length; i++ )
			{
				GameObject[] boxes = GameManager.manager.msgBoxes;
				new Messages(messages[i].senderName, messages[i].message, boxes // finish this and add the whole find child thing 
			}
		}*/
	
		// contactZero.tex= GameManager.manager.no [0].text;
		/*for(int i = 0; i <= GameManager.manager.msgs.Length, i++)
		{
			// create position and etc

			GameManager.manager.msgs[i].name
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space"))
		{
			// GameObject[] msgs;

			GameManager.manager.msgBoxes = GameObject.FindGameObjectsWithTag("message"); 

			for(int i = 0; i < GameManager.manager.msgBoxes.Length; i++ )
			{
				GameManager.manager.msgBoxes[i].transform.Translate(0,70,0);
				Debug.Log ("beep " + i);
			}
			GameManager.manager.msgs.Add( new Messages("hi", Time.time.ToString(), senderName, message, messageBox, false));
		}
	}

	void OnDisable()
	{
		for(int i = 0; i < GameManager.manager.msgBoxes.Length; i++ )
		{
			GameManager.manager.msgs [i].boxPos = GameManager.manager.msgBoxes [i].transform.position;
			Debug.Log ("beep " + i);
		}
	}

	public void OnString_Notes(string value)
	{
		// set player name to the value of the uppercased value of the input
		// GameManager.manager.no[contact].text = value;
	}
}
