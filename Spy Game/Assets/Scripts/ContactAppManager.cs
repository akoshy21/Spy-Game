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

		InitializeOptions ();

		// add previous messages
		foreach(Messages ms in GameManager.manager.msgs)
		{
			new Messages (ms.senderName, ms.message, senderName, message, messageBox, ms.isPlayer);
			Debug.Log (ms.isPlayer);
		}

		if (GameManager.manager.contactStartup == false)
		{
			//new Messages (handlerName, "Hello Agent. It's been a while. Welcome to the world.", false);
			GameManager.manager.msgs.Add(new Messages(handlerName, "Hello. \nI'm sure this must be a bit confusing, but we need your help.", senderName, message, messageBox, false));
			GameManager.manager.contactStartup = true;
		}

		//FillOptions (GameManager.manager.optionIndex);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space"))
		{
			GameManager.manager.msgs.Add( new Messages("hi", Time.time.ToString(), senderName, message, messageBox, false));
		}
		Debug.Log (messageBox.GetComponent<RectTransform>().rect.height);
	}

	void OnDisable()
	{
	}

	public void InitializeOptions()
	{
		GameManager.manager.optionList.Add (new Options ("Who are you?", "What is this?", "Help with what?", 1, 1, 1));
		GameManager.manager.optionList.Add (new Options ("Who is this?", "I'm not an agent.", "Who's an agent??", 1, 1, 1));
		GameManager.manager.optionList.Add (new Options ("Who is this?", "I'm not an agent.", "Who's an agent??", 1, 1, 1));

	}

	public void FillOptions(int o)
	{
		
	}
}
