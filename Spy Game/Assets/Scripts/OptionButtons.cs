using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		}
		if (optionNum == 2)
		{
		}
		if (optionNum == 3)
		{
		}
	}
}
