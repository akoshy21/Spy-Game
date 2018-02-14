﻿using System.Collections;
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

	// Use this for initialization
	void Start () {
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
	}

	void OptionsOnClick()
	{
		GameManager.manager.UpdateMessagePos ();
		if (optionNum == 1)
		{
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.playerName, GameManager.manager.optionList[GameManager.manager.optionIndex].optionOne, senderName, message, messageBox, true));
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].effectOne;
			EventSystem.current.SetSelectedGameObject (null);
		}
		if (optionNum == 2)
		{
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.playerName, GameManager.manager.optionList[GameManager.manager.optionIndex].optionTwo, senderName, message, messageBox, true));
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].effectTwo;
			EventSystem.current.SetSelectedGameObject (null);
		}
		if (optionNum == 3)
		{
			GameManager.manager.msgs.Add(new Messages(GameManager.manager.playerName, GameManager.manager.optionList[GameManager.manager.optionIndex].optionThree, senderName, message, messageBox, true));
			GameManager.manager.personality += GameManager.manager.optionList [GameManager.manager.optionIndex].effectThree;
			EventSystem.current.SetSelectedGameObject (null);
		}
	}
}