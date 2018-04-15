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

		handlerLoaded = GameManager.manager.checkIfLoaded ("Messenger");
		suspectLoaded = GameManager.manager.checkIfLoaded ("Suspect");

		// Debug.Log (handlerLoaded);

		windowbg = GameObject.FindGameObjectWithTag ("windowbg"); 

		if (handlerLoaded)
		{
			// Debug.Log ("HANDLER IS LOADED");
			GameManager.manager.newMessageHandler = false;

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

			if (GameManager.manager.suspectStartup == false)
			{
				GameManager.manager.suspect.Add(new Messages(GameManager.manager.suspectName, "Hey! It's been a while. How's it going?", senderName, message, messageBox, false));
				GameManager.manager.suspectStartup = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log(GameManager.manager.checkIfLoaded ("Messenger"));
		GameManager.manager.CheckForClicks ();

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

		if (newResponse == true)
		{
			coroutine = AddResponse (rNum);
            StartCoroutine(coroutine);
		}
	}

	void OnDisable()
	{
	}



    public IEnumerator AddResponse(int responseNum)
    {
        GameObject[] optionbuttons = GameObject.FindGameObjectsWithTag("option");

        for (int i = 0; i < optionbuttons.Length; i++)
        {
            optionbuttons[i].SetActive(false);
        }

		if(handlerLoaded)
		{
			responding.GetComponentInChildren<Text>().text = GameManager.manager.handlerName + " is replying...";
		}
		else if(suspectLoaded)
		{
			responding.GetComponentInChildren<Text>().text = GameManager.manager.suspectName + " is replying...";
		}

		responding.gameObject.SetActive (true);

		yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
        if (oneMsg == true)
        {
			respond (responseNum);
			twoMsg = true;
        }

		yield return new WaitForSeconds(Random.Range(1.5f, 2.0f));
		responding.gameObject.SetActive (false);
        if (twoMsg == true)
        {
			if (handlerLoaded) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.handlerName, Handler.handler.responses [GameManager.manager.handlerR], senderName, message, messageBox, false));
				GameManager.manager.handlerR++;
			}
			if (suspectLoaded) {
				GameManager.manager.suspect.Add (new Messages (GameManager.manager.suspectName, Suspect.suspect.responses [GameManager.manager.suspectR], senderName, message, messageBox, false));
				GameManager.manager.suspectR++;
			}

            twoMsg = false;
        }
		yield return new WaitForSeconds (0.5f);
        for (int i = 0; i < optionbuttons.Length; i++)
        {
            optionbuttons[i].SetActive(true);
        }
		newResponse = false;
	
	}

	public 

	void respond(int num)
	{
		if (handlerLoaded) {	
			if (num == 1) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.handlerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex - 1].responseOne, senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 2) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.handlerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex - 1].responseTwo, senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 3) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.handlerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex - 1].responseThree, senderName, message, messageBox, false));
				oneMsg = false;
			}
		}
		if (suspectLoaded) {
			if (num == 1) {
				GameManager.manager.suspect.Add (new Messages (
					GameManager.manager.suspectName, 
					GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex - 1].responseOne, 
					senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 2) {
				GameManager.manager.suspect.Add (new Messages (
					GameManager.manager.suspectName, 
					GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex - 1].responseTwo, 
					senderName, message, messageBox, false));
				oneMsg = false;
			} else if (num == 3) {
				GameManager.manager.suspect.Add (new Messages (
					GameManager.manager.suspectName, 
					GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex - 1].responseThree, 
					senderName, message, messageBox, false));
				oneMsg = false;
			}
		}
	}
}
