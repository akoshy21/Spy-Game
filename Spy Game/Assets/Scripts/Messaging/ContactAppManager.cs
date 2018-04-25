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
	public bool newResponseTwo = false;

    public int rNum;

    private IEnumerator coroutine;

    public bool oneMsg = true;
    public bool twoMsg = true;

	public AudioClip keys;

	bool handlerLoaded;
	bool suspectLoaded;

	bool pause;

	public bool optionsOn = true;

	public GameObject[] optionbuttons;

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

		optionbuttons = GameObject.FindGameObjectsWithTag("option");

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

		if (handlerLoaded) 
		{
			pause = GameManager.manager.handlerPause;
		}
		else if(suspectLoaded)
		{
			pause = GameManager.manager.suspectPause;
		}
			
        // Debug.Log(newResponse);

		// add response if newresponse == true

		if (newResponse == true && pause != true)
		{
			coroutine = AddResponse (rNum);
            StartCoroutine(coroutine);
		}

		if (GameManager.manager.handlerR > 2) {
			//Debug.Log ("We're big now");
			Variables.variable.suspectButton.SetActive (true);
		}

		if (GameManager.manager.msgs.Count >= 27) {
			Debug.Log ("he");
			GameManager.manager.end = 12;
			GameManager.manager.handlerPause = true;
			StartCoroutine (GameManager.manager.EndGame ());
		}
		else if (GameManager.manager.suspect [0].decision == 3) {
			Debug.Log ("BEEP");
			GameManager.manager.end = 1;
			StartCoroutine (GameManager.manager.EndGame ());
		} else if (GameManager.manager.suspect [12].decision == 3) {
			Debug.Log ("BEEP");
			GameManager.manager.end = 2;
			StartCoroutine (GameManager.manager.EndGame ());
		} else if (GameManager.manager.suspect [15].decision == 1) {
			Debug.Log ("BEEP");
			GameManager.manager.end = 3;
			StartCoroutine (GameManager.manager.EndGame ());
		} else if (GameManager.manager.suspect [18].decision == 3 || GameManager.manager.suspect [18].decision == 2) {
			Debug.Log ("BEEP");
			GameManager.manager.end = 4;
			StartCoroutine (GameManager.manager.EndGame ());
		} else if (GameManager.manager.suspect [21].decision == 3 || GameManager.manager.suspect [21].decision == 2) {
			Debug.Log ("BEEP");
			GameManager.manager.end = 5;
			StartCoroutine (GameManager.manager.EndGame ());
		} else if (GameManager.manager.suspect [24].decision == 1 || GameManager.manager.suspect [24].decision == 2) {
			Debug.Log ("BEEP");
			GameManager.manager.end = 6;
			StartCoroutine (GameManager.manager.EndGame ());
		}
		else if ((GameManager.manager.suspect.Count - 1) == 31)
		{
			if (GameManager.manager.suspect [27].decision == 1 || GameManager.manager.suspect [30].decision == 1) {
				Debug.Log ("BEEP");
				GameManager.manager.end = 7;
			}
			else if (GameManager.manager.suspect [27].decision == 2 || GameManager.manager.suspect [30].decision == 1) {
				GameManager.manager.end = 8;
			}
			else if (GameManager.manager.suspect [27].decision == 3 || GameManager.manager.suspect [30].decision == 1) {
				GameManager.manager.end = 9;
			}
			else if ((GameManager.manager.suspect [27].decision == 1 && GameManager.manager.suspect [30].decision == 2) || 
				(GameManager.manager.suspect [27].decision == 2 && GameManager.manager.suspect [30].decision == 2) || 
				(GameManager.manager.suspect [27].decision == 3 || GameManager.manager.suspect [30].decision == 2)) {
				GameManager.manager.end = 10;
			}
			else if ((GameManager.manager.suspect [27].decision == 1 && GameManager.manager.suspect [30].decision == 3) || 
				(GameManager.manager.suspect [27].decision == 2 && GameManager.manager.suspect [30].decision == 3) || 
				(GameManager.manager.suspect [27].decision == 3 || GameManager.manager.suspect [30].decision == 3)) {
				GameManager.manager.end = 11;
			}
			StartCoroutine(GameManager.manager.EndGame ());
		}
	}

	void OnDisable()
	{
	}



    public IEnumerator AddResponse(int responseNum)
	{
		// Debug.Log ("Howdy");
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

			Debug.Log (twoMsg);

			yield return new WaitForSeconds(Random.Range(1.5f, 2.0f));

			if (newResponseTwo == false && pause != true && newResponse == true) {
				Debug.Log ("one reply");
				ToggleOptions ();
				newResponse = false;
				newResponseTwo = false;
			}

			if (newResponseTwo == true && pause != true) {
				Debug.Log ("Adding Bit Two");
				StartCoroutine (AddResponseTwo ());
				newResponse = false;
				newResponseTwo = false;
			}

			Debug.Log (twoMsg);
        }
			

	}

	public IEnumerator AddResponseTwo()
	{
		if (twoMsg == true)
		{
			Debug.Log (GameManager.manager.handlerR + " " + twoMsg);
			if (handlerLoaded && twoMsg) {
				Debug.Log ("MsgAdded");
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
		yield return new WaitForSeconds (0.2f);

		responding.gameObject.SetActive (false);

		yield return new WaitForSeconds (0.9f);

		ToggleOptions ("r2");
	}

	public void ToggleOptions(string debugText = null){
		// find the option buttons
		if (optionsOn) {
			Debug.Log ("toggling off - " + debugText);
			// set the buttons to false / hide them
			for (int i = 0; i < optionbuttons.Length; i++) {
				optionbuttons [i].SetActive (false);
			}
			optionsOn = false;
			return;
		} else if (optionsOn == false){
			Debug.Log ("toggling - " + debugText);
			for (int i = 0; i < optionbuttons.Length; i++)
			{
				optionbuttons[i].SetActive(true);
			}
			optionsOn = true;
			return;
		}
	}

	public void respond(int num)
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
