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

	public bool newResponse = false;

	public int rNum;
	public int r = 0;
//	List<Messages> messages;
//	GameObject[] boxes;

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
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, "Hello. \nI'm sure this must be a bit confusing, but we need your help.", senderName, message, messageBox, false));
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

		if (newResponse == true)
		{
			AddResponse (rNum);
		}
	}

	void OnDisable()
	{
	}

	public void InitializeOptions()
	{
		GameManager.manager.optionList.Add (new Options ("Who are you?", "What is this?", "Help with what?", "It doesn't matter right now. We have a problem. We're calling you in. ", "There's a lot to explain. There's a problem with our mutual friends.", "Let me take a moment to explain.", 1, 1, 1));
		GameManager.manager.optionList.Add (new Options ("Calling me in?", "Wait for what?", "Secret secret?", "It doesn't matter right now.", "There's a lot to explain.", "Let me take a moment to explain.", 1, 1, 1));
		GameManager.manager.optionList.Add (new Options ("This is a word.", "Why?", "Help with what?", "It doesn't matter right now.", "There's a lot to explain.", "Let me take a moment to explain.", 1, 1, 1));

	}

	public IEnumerator AddResponse(int responseNum)
	{
		GameObject[] optionbuttons = GameObject.FindGameObjectsWithTag("option");

		for(int i = 0; i < optionbuttons.Length; i++)
		{
			optionbuttons[i].SetActive(false);
		}

		yield return new WaitForSeconds(1);
		if (responseNum == 1)
		{
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, GameManager.manager.optionList[GameManager.manager.optionIndex].responseOne, senderName, message, messageBox, false));
		}
		else if (responseNum == 2)
		{
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, GameManager.manager.optionList[GameManager.manager.optionIndex].responseTwo, senderName, message, messageBox, false));
		}
		else if (responseNum == 3)
		{
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, GameManager.manager.optionList[GameManager.manager.optionIndex].responseThree, senderName, message, messageBox, false));
		}
			
		yield return new WaitForSeconds(0.5f);

		GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, GameManager.manager.responses[r], senderName, message, messageBox, false));

		yield return new WaitForSeconds (0.5f);
		for(int i = 0; i < optionbuttons.Length; i++)
		{
			optionbuttons[i].SetActive(true);
		}

		r++;
		newResponse = false;
	}

}
