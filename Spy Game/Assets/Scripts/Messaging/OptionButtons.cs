using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionButtons : MonoBehaviour {
	
	public int optionNum;
	public Text buttonTxt;

	public Text senderName;
	public Text message;
	public Image messageBox;

	public KeyCode key;

	public GameObject contactApp;

	// Use this for initialization
	void Start () {
		if (optionNum == 1)
		{
			key = KeyCode.Alpha1;
		}
		if (optionNum == 2)
		{
			key = KeyCode.Alpha2;
		}
		if (optionNum == 3)
		{
			key = KeyCode.Alpha3;
		}
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (OptionsOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.manager.handlerPause == false && GameManager.manager.checkIfLoaded("Messenger")) {
			if (optionNum == 1) {
				buttonTxt.text = GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].optionOne;
			}
			if (optionNum == 2) {
				buttonTxt.text = GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].optionTwo;
			}
			if (optionNum == 3) {
				buttonTxt.text = GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].optionThree;
			}
		}
		if (GameManager.manager.suspectPause == false && GameManager.manager.checkIfLoaded("Suspect")) {
			if (optionNum == 1) {
				buttonTxt.text = GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].optionOne;
			}
			if (optionNum == 2) {
				buttonTxt.text = GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].optionTwo;
			}
			if (optionNum == 3) {
				buttonTxt.text = GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].optionThree;
			}
		}
		if (Input.GetKeyDown (key)) {
			this.GetComponent<Button> ().onClick.Invoke ();
		}
	}

	void OptionsOnClick()
	{
		msgResponse ();
		TriggerResponse(optionNum);

		decisionResult (optionNum);
		contactApp.GetComponent<ContactAppManager>().ToggleOptions ("options");

		contactApp.GetComponent<AudioSource> ().Play ();
	}

	void msgResponse()
	{
		if (GameManager.manager.checkIfLoaded ("Messenger")) {
			if (optionNum == 1) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.playerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].optionOne, senderName, message, messageBox, true, 1));
				GameManager.manager.personality += GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].effectOne;
			} else if (optionNum == 2) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.playerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].optionTwo, senderName, message, messageBox, true, 2));
				GameManager.manager.personality += GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].effectTwo;
			} else if (optionNum == 3) {
				GameManager.manager.msgs.Add (new Messages (GameManager.manager.playerName, GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].optionThree, senderName, message, messageBox, true, 3));
				GameManager.manager.personality += GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].effectThree;
			}
			Debug.Log (GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].replies);
			if (GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].replies != 0) {
				contactApp.GetComponent<ContactAppManager> ().newResponse = true;
				if (GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].replies == 1) {
					contactApp.GetComponent<ContactAppManager> ().newResponseTwo = false;
				} else if (GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].replies == 2) {
					contactApp.GetComponent<ContactAppManager> ().newResponseTwo = true;
				}
			}
				
			contactApp.GetComponent<ContactAppManager>().oneMsg = true;
				
			GameManager.manager.handlerOptionIndex++;
			// TriggerResponse(optionNum);
		}


		if (GameManager.manager.checkIfLoaded ("Suspect")) {
			if (optionNum == 1)
			{
				GameManager.manager.suspect.Add(new Messages(GameManager.manager.playerName, GameManager.manager.suspectOptionList[GameManager.manager.suspectOptionIndex].optionOne, senderName, message, messageBox, true, 1));
				GameManager.manager.personality += GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].effectOne;
			}
			else if (optionNum == 2)
			{
				GameManager.manager.suspect.Add(new Messages(GameManager.manager.playerName, GameManager.manager.suspectOptionList[GameManager.manager.suspectOptionIndex].optionTwo, senderName, message, messageBox, true, 2));
				GameManager.manager.personality += GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].effectTwo;
			}
			else if (optionNum == 3)
			{
				GameManager.manager.suspect.Add(new Messages(GameManager.manager.playerName, GameManager.manager.suspectOptionList[GameManager.manager.suspectOptionIndex].optionThree, senderName, message, messageBox, true, 3));
				GameManager.manager.personality += GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].effectThree;
			}

			contactApp.GetComponent<ContactAppManager>().oneMsg = true;

			if (GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].replies != 0) {
				contactApp.GetComponent<ContactAppManager> ().newResponse = true;
				Debug.Log (GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].replies);

				if (GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].replies == 1) {
					contactApp.GetComponent<ContactAppManager> ().newResponseTwo = false;
				} else if (GameManager.manager.suspectOptionList [GameManager.manager.suspectOptionIndex].replies == 2) {
					contactApp.GetComponent<ContactAppManager> ().newResponseTwo = true;
				}
			}

			GameManager.manager.suspectOptionIndex++;
		}
	}

	void decisionResult(int num)
	{
		EventSystem.current.SetSelectedGameObject (null);
		GameManager.manager.handlerOptionList [GameManager.manager.handlerOptionIndex].optionSelected = num;

		contactApp.GetComponent<ContactAppManager> ().rNum = optionNum;
	}

	void TriggerResponse(int rNum)
	{
		Debug.Log ("Triggering");
		IEnumerator co = contactApp.GetComponent<ContactAppManager>().AddResponse(rNum);
		StartCoroutine(co);
		Debug.Log ("triggered");
	}

}
