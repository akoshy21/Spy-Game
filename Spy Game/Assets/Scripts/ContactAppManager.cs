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

	public GameObject windowbg; 
//	List<Messages> messages;
//	GameObject[] boxes;

	public string handlerName = "X";

	/// public Text contactZero;

	// Use this for initialization
	void OnEnable () {

		windowbg = GameObject.FindGameObjectWithTag ("windowbg"); 

		GameManager.manager.newMessage = false;

		// add previous messages
		foreach(Messages ms in GameManager.manager.msgs)
		{
			GameManager.manager.msgBoxes = GameObject.FindGameObjectsWithTag("message"); 

			//GameManager.manager.msgs [i].boxPos = GameManager.manager.msgBoxes [i].transform.position;
			for(int i = 0; i < GameManager.manager.msgBoxes.Length; i++ )
			{
				GameManager.manager.msgBoxes[i].transform.Translate(0,GameManager.manager.msgBoxes[i].GetComponent<RectTransform>().rect.height,0);
				Debug.Log ("pop " + i);
			}
			new Messages (ms.senderName, ms.message, senderName, message, messageBox, ms.isPlayer);
		}

		if (GameManager.manager.contactStartup == false)
		{
			//new Messages (handlerName, "Hello Agent. It's been a while. Welcome to the world.", false);
			GameManager.manager.msgs.Add(new Messages(handlerName, "HI THERE", senderName, message, messageBox, false));
			GameManager.manager.contactStartup = true;
		}
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
// 				if(GameManager.manager.msgBoxes[i].transform.position > // delete msgs higher than x pt
			}
			GameManager.manager.msgs.Add( new Messages("hi", Time.time.ToString(), senderName, message, messageBox, false));
		}
	}

	void OnDisable()
	{
		for(int i = 0; i < GameManager.manager.msgBoxes.Length; i++ )
		{
			Debug.Log ("beep " + i);
		}
	}

	public void OnString_Notes(string value)
	{
		// set player name to the value of the uppercased value of the input
		// GameManager.manager.no[contact].text = value;
	}
}
