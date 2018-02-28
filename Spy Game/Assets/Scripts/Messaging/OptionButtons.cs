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
		if (optionNum == 1)
		{
			buttonTxt.text = GameManager.manager.optionList[GameManager.manager.optionIndex].optionOne;
		}
		if (optionNum == 2)
		{
			buttonTxt.text = GameManager.manager.optionList[GameManager.manager.optionIndex].optionTwo;
		}
		if (optionNum == 3)
		{
			buttonTxt.text = GameManager.manager.optionList[GameManager.manager.optionIndex].optionThree;
		}

		if(Input.GetKeyDown(key))
		{
			this.GetComponent<Button>().onClick.Invoke();
		}
	}

	void OptionsOnClick()
	{
		if (optionNum == 1)
		{
			GameManager.manager.msgs.Add(new Messages("Agent 0-21", GameManager.manager.optionList[GameManager.manager.optionIndex].optionOne, senderName, message, messageBox, true));
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].effectOne;
			EventSystem.current.SetSelectedGameObject (null);
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].optionSelected = 1;

			contactApp.GetComponent<ContactAppManager> ().rNum = optionNum;
		}
		else if (optionNum == 2)
		{
			GameManager.manager.msgs.Add(new Messages("Agent 0-21", GameManager.manager.optionList[GameManager.manager.optionIndex].optionTwo, senderName, message, messageBox, true));
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].effectTwo;
			EventSystem.current.SetSelectedGameObject (null);
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].optionSelected = 2;

			contactApp.GetComponent<ContactAppManager> ().rNum = optionNum;
		}
		else if (optionNum == 3)
		{
			GameManager.manager.msgs.Add(new Messages("Agent 0-21", GameManager.manager.optionList[GameManager.manager.optionIndex].optionThree, senderName, message, messageBox, true));
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].effectThree;
			EventSystem.current.SetSelectedGameObject (null);
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].optionSelected = 3;

			contactApp.GetComponent<ContactAppManager> ().rNum = optionNum;
		}

        contactApp.GetComponent<ContactAppManager>().oneMsg = true;
        contactApp.GetComponent<ContactAppManager>().twoMsg = true;
        contactApp.GetComponent<ContactAppManager> ().newResponse = true;
		GameManager.manager.optionIndex++;
	}

}
