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
	public GameObject responding;

	public bool newResponse = false;

    public int rNum;

    private IEnumerator coroutine;

    public bool oneMsg = true;
    public bool twoMsg = true;

	public AudioClip keys;

	bool handlerLoaded;
	bool suspectLoaded;


    //	List<Messages> messages;
    //	GameObject[] boxes;

    /// public Text contactZero;

    // Use this for initialization
    void OnEnable () {

		// check if these scenes are loaded
		handlerLoaded = GameManager.manager.checkIfLoaded ("Messenger");
		suspectLoaded = GameManager.manager.checkIfLoaded ("Suspect");

		// Debug.Log (handlerLoaded);

		// find and set windowbg to the right object
		windowbg = GameObject.FindGameObjectWithTag ("windowbg"); 

		if (handlerLoaded)
		{
			// Debug.Log ("HANDLER IS LOADED");

			// turn newmessage to false
			GameManager.manager.newMessageHandler = false;

			// init responses and options
			Handler.handler.InitializeOptions ();
			Handler.handler.InitializeResponses();

			// add previous messages
			foreach(Messages ms in GameManager.manager.msgs)
			{
				GameManager.manager.reinit = true;
				new Messages (ms.senderName, ms.message, senderName, message, messageBox, ms.isPlayer);
				// Debug.Log (ms.isPlayer);
				GameManager.manager.reinit = false;
			}

			// if startup is false
			if (GameManager.manager.contactStartup == false)
			{
				GameManager.manager.msgs.Add(new Messages(GameManager.manager.handlerName, "Hello. \nI'm sure this must be a bit confusing, but we need your help, and there isn't much time to explain.", senderName, message, messageBox, false));
				GameManager.manager.contactStartup = true;
			}
		}

		else if (suspectLoaded) {
			GameManager.manager.newMessageSuspect = false;

			Suspect.suspect.InitializeOptions ();
			Suspect.suspect.InitializeResponses();

			// add previous messages
			foreach(Messages ms in GameManager.manager.suspect)
			{
				GameManager.manager.reinit = true;
				new Messages (ms.senderName, ms.message, senderName, message, messageBox, ms.isPlayer);
				// Debug.Log (ms.isPlayer);
				GameManager.manager.reinit = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log(GameManager.manager.checkIfLoaded ("Messenger"));

		// check for clicks to make sound
		GameManager.manager.CheckForClicks ();

		// if space print hi shit
		if (Input.GetKeyDown ("space"))
		{
			if (handlerLoaded) 
			{
				GameManager.manager.msgs.Add (new Messages ("hi", Time.time.ToString (), senderName, message, messageBox, false));
			}
			else if(suspectLoaded)
			{
				GameManager.manager.suspect.Add (new Messages ("hi", Time.time.ToString (), senderName, message, messageBox, false));
			}
		}
			
        // Debug.Log(newResponse);

		// add response if newresponse == true
		if (newResponse == true)
		{
			coroutine = AddResponse (rNum);
            StartCoroutine(coroutine);
		}

		if (Handler.handler.responses.Length > 3) {
			GameManager.manager.suspectButton.SetActive (true);
		}
	}

	void OnDisable()
	{
	}



    public IEnumerator AddResponse(int responseNum)
    {
		// find the option buttons
        GameObject[] optionbuttons = GameObject.FindGameObjectsWithTag("option");

		// set the buttons to false / hide them
        for (int i = 0; i < optionbuttons.Length; i++)
        {
            optionbuttons[i].SetActive(false);
        }

		// check which is loaded and display the appropriate response text
		if(handlerLoaded)
		{
			responding.GetComponentInChildren<Text>().text = GameManager.manager.handlerName + " is typing...";
		}
		else if(suspectLoaded)
		{
			responding.GetComponentInChildren<Text>().text = GameManager.manager.suspectName + " is typing...";
		}

		// set responding to true
		responding.gameObject.SetActive (true);

		// wait
		yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
        
		// if one msg is true, respond, and set msg two to true
		if (oneMsg == true)
        {
			respond (responseNum);
			twoMsg = true;
        }
			
		yield return new WaitForSeconds(Random.Range(1.5f, 2.0f));


        if (twoMsg == true)
        {
			Debug.Log (GameManager.manager.handlerR + " " + twoMsg);
			if (handlerLoaded && twoMsg) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.handlerName, Handler.handler.responses [GameManager.manager.handlerR], senderName, message, messageBox, false));
				twoMsg = false;
				GameManager.manager.handlerR++;
			}
			if (suspectLoaded && twoMsg) {
				GameManager.manager.suspect.Add (new Messages (GameManager.manager.suspectName, Suspect.suspect.responses [GameManager.manager.suspectR], senderName, message, messageBox, false));
				twoMsg = false;
				GameManager.manager.suspectR++;
			}
        }
		yield return new WaitForSeconds (0.5f);

		responding.gameObject.SetActive (false);

        for (int i = 0; i < optionbuttons.Length; i++)
        {
            optionbuttons[i].SetActive(true);
        }
		newResponse = false;
	
	}

	void respond(int num)
	{
		// check which scene is loaded and then display the appropriate response based on what option the player selected, referencing the game manager's option list and index

		if (handlerLoaded) {	
			if (num == 1) {
				GameManager.manager.msgs.Add (new Messages (
					GameManager.manager.handlerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex - 1].responseOne, senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 2) {
				GameManager.manager.msgs.Add (new Messages (
					GameManager.manager.handlerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex - 1].responseTwo, senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 3) {
				GameManager.manager.msgs.Add (new Messages (
					GameManager.manager.handlerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex - 1].responseThree, senderName, message, messageBox, false));
				oneMsg = false;
			}
		}
		if (suspectLoaded) {
			if (num == 1) {
				GameManager.manager.suspect.Add (new Messages (
					GameManager.manager.suspectName, GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex - 1].responseOne, senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 2) {
				GameManager.manager.suspect.Add (new Messages (
					GameManager.manager.suspectName, GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex - 1].responseTwo, senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 3) {
				GameManager.manager.suspect.Add (new Messages (
					GameManager.manager.suspectName, GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex - 1].responseThree, senderName, message, messageBox, false));
				oneMsg = false;
			}
		}
	}
}
